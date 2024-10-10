"use strict";
// Add event listener for opening and closing details
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})

var KTUsersList = (function () {
    var e,
        t,
        n,
        r,
        o = document.getElementById("kt_table_memo"),
        c = () => {
            o.querySelectorAll('[data-kt-users-table-filter="delete_row"]').forEach((t) => {
                t.addEventListener("click", function (t) {
                    t.preventDefault();
                    const n = t.target.closest("tr"),
                        r = n.querySelectorAll("td")[1].querySelectorAll("a")[1].innerText;
                    Swal.fire({
                        text: "Are you sure you want to delete " + r + "?",
                        icon: "warning",
                        showCancelButton: !0,
                        buttonsStyling: !1,
                        confirmButtonText: "Yes, delete!",
                        cancelButtonText: "No, cancel",
                        customClass: { confirmButton: "btn fw-bold btn-danger", cancelButton: "btn fw-bold btn-active-light-primary" },
                    }).then(function (t) {
                        t.value
                            ? Swal.fire({ text: "You have deleted " + r + "!.", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn fw-bold btn-primary" } })
                                .then(function () {
                                    e.row($(n)).remove().draw();
                                })
                                .then(function () {
                                    a();
                                })
                            : "cancel" === t.dismiss && Swal.fire({ text: customerName + " was not deleted.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn fw-bold btn-primary" } });
                    });
                });
            });
        },
        l = () => {
            const c = o.querySelectorAll('[type="checkbox"]');
            (t = document.querySelector('[data-kt-user-table-toolbar="base"]')), (n = document.querySelector('[data-kt-user-table-toolbar="selected"]')), (r = document.querySelector('[data-kt-user-table-select="selected_count"]'));
            const s = document.querySelector('[data-kt-user-table-select="delete_selected"]');
            c.forEach((e) => {
                e.addEventListener("click", function () {
                    setTimeout(function () {
                        a();
                    }, 50);
                });
            });
        };
    const a = () => {
        const e = o.querySelectorAll('tbody [type="checkbox"]');
        let c = !1,
            l = 0;
        e.forEach((e) => {
            e.checked && ((c = !0), l++);
        })
            //,
            //c ? ((r.innerHTML = l),
            //    t.classList.add("d-none"),
            //    n.classList.remove("d-none")) : (t.classList.remove("d-none"), n.classList.add("d-none"))
            //;
    };

    return {
        init: function () {
            o &&
                (o.querySelectorAll("tbody tr").forEach((e) => {
                    const t = e.querySelectorAll("td"),
                        n = t[3].innerText.toLowerCase();
                    let r = 0,
                        o = "minutes";
                    n.includes("yesterday")
                        ? ((r = 1), (o = "days"))
                        : n.includes("mins")
                            ? ((r = parseInt(n.replace(/\D/g, ""))), (o = "minutes"))
                            : n.includes("hours")
                                ? ((r = parseInt(n.replace(/\D/g, ""))), (o = "hours"))
                                : n.includes("days")
                                    ? ((r = parseInt(n.replace(/\D/g, ""))), (o = "days"))
                                    : n.includes("weeks") && ((r = parseInt(n.replace(/\D/g, ""))), (o = "weeks"));
                    const c = moment().subtract(r, o).format();
                    t[3].setAttribute("data-order", c);
                    const l = moment(t[5].innerHTML, "DD MMM YYYY, LT").format();
                    t[5].setAttribute("data-order", l);
                }),
                    (e = $(o).DataTable({
                        info: !1,
                        order: [],
                        pageLength: 20,
                        lengthChange: !1,
                        ajax: {
                            url: 'http://localhost:5101/api/Recovery/Recovery/GetMemoList',
                            type: 'POST'
                        },
                        columns: [
                            
                            // {
                            //     "render": function (data, type, row) {
                            //         return "<div class='form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input' type='checkbox' value='1' /></div>";
                            //     }
                            // },
                            {
                                "render": function ( data, type, full, meta ) {
                                    return  meta.row + 1;
                                }
                            },
                            {
                                "data": "memo_no",
                                "render": function (data, type, row) {
                                    return "<div class='form-check form-check-sm form-check-custom form-check-solid'><a href=\"Recovery/Memo/Details?id=" + row.id + "\">" + row.memo_no + "</a></div>";
                                }
                            },
                            {
                                "data": "title",
                                "render": function (data, type, row) {
                                    return "<div class='form-check form-check-sm form-check-custom form-check-solid' data-bs-toggle='tooltip' data-bs-placement='top' data-bs-trigger='hover' title='" + row.description + "'><a class=\"text-black\" href=\"Recovery/Memo/Details?id=" + row.id + "\">" + row.title + "</a></div>";
                                }
                            },
                            {
                                "data": "memostatusid",
                                "render": function (data, type, row) {
                                    var _status = "";
                                    if (row.memostatusid == "N") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-primary pulse pulse-primary\"><span class=\"pulse-ring\"></span>NEW MEMO</span></a>";
                                    if (row.memostatusid == "SAA") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-warning\">SUBMIT APPENDIX A</span></a>";
                                    if (row.memostatusid == "AAA") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">APPROVED APPENDIX A</span></a>";
                                    if (row.memostatusid == "AM") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">APPROVED MEMO</span></a>";
                                    if (row.memostatusid == "R") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-info\">RELEASE</span></a>";

                                    return "<div class='form-check form-check-sm form-check-custom form-check-solid'><span><a class=\"text-black\" href=\"Recovery/Memo/Details?id=" + row.id + "\">" + (_status != "" ? _status : "<i class=\"text-danger\">Scholar status not found</i>") + "</span></div>";
                                }
                            },
                            // {
                            //     "data": "letter_issuance_date",
                            //     "render": function (data, type, row) {
                            //         return "<div class='form-check form-check-sm form-check-custom form-check-solid'>" + row.letter_issuance_date + "</div>";
                            //     }
                            // },
                            
                            
                        ],
                        //processing: true,
                        //serverSide: true
                    })).on("draw", function () {
                        l(), c(), a();
                    }),
                    l(),
                    document.querySelector('[data-kt-user-table-filter="search"]').addEventListener("keyup", function (t) {
                        e.search(t.target.value).draw();
                    }),
                    
                    c(),
                    (() => {
                        //const t = document.querySelector('[data-kt-user-table-filter="form"]'),
                           /* n = t.querySelector('[data-kt-user-table-filter="filter"]'),*/
                            //r = t.querySelectorAll("select");
                        //n.addEventListener("click", function () {
                        //    var t = "";
                        //    r.forEach((e, n) => {
                        //        e.value && "" !== e.value && (0 !== n && (t += " "), (t += e.value));
                        //    }),
                        //        e.search(t).draw();
                        //});
                    })(
                    ));
        },
    };
})();
KTUtil.onDOMContentLoaded(function () {
    KTUsersList.init();
});
