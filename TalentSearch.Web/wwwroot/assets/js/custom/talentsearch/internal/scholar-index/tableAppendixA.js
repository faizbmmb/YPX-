"use strict";
// Add event listener for opening and closing details

var KTUsersList = (function () {
    var e,
        t,
        n,
        r,
        o = document.getElementById("kt_table_appendix"),
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
                        // scrollX: true,
                        ajax: {
                            url: 'http://localhost:5101/api/Recovery/Recovery/GetAppendixAList',
                            type: 'POST'
                        },
                        columns: [

                            // {
                            //     "render": function (data, type, row) {
                            //         return "<a href=\"Recovery/Memo/Details/View?id=" + row.scholar_nric + "\">View</a>";
                            //         // return "<div class='form-check form-check-sm form-check-custom form-check-solid'><input name='checkbox_AA' class='form-check-input' type='checkbox' value='1' /></div>";
                            //     }
                            // },
                            {
                                "render": function (data, type, full, meta) {
                                    return meta.row + 1;
                                }
                            },
                            {
                                data: 'scholar_name',
                                "render": function (data, type, row) {
                                    return "<div class=\"d-flex flex-column\">" +
                                        "<span><b>" + row.scholar_name + "</span></b><span>" + row.scholar_nric + "</span>" +
                                        "<span>" + (row.email != null ? row.email.toLowerCase() : "<i class=\"text-danger\">Email not found</i>") + "</span>" +
                                        "</div>";
                                }
                            },
                            {
                                data: 'scholar_name',
                                "render": function (data, type, row) {
                                    // var _straight_passer = "";
                                    var _status = "";
                                    if (row.status == "COMPLETION") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">COMPLETION</span>";
                                    if (row.status == "TERMINATION") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-danger\">TERMINATION</span>";

                                    return "<div class=\"d-flex flex-column\">" +
                                        // "<span><b>Cost Code: </b>" + (row.cost_code != null ? row.cost_code : "<i class=\"text-danger\">Data not found</i>") + "</span> " +
                                        "<span><b>Programme: </b>" + (row.programme_name != null ? row.programme_name : "<i class=\"text-danger\">Data not found</i>") + "</span> " +
                                        // "<span><b>Year: </b>" + (row.year != null ? row.year : "<i class=\"text-danger\">Data not found</i>") + "</span> " +
                                        // "<span><b>Straight Passer: </b>" + (_straight_passer != "" ? _straight_passer : "<i class=\"text-danger\">Data not found</i>") + "</span> " +
                                        "<span><b>Scholar Status: </b>" + (_status != "" ? _status : "<i class=\"text-danger\">Scholar Status not found</i>") + "</span> " +
                                        "</div>";
                                }
                            },
                            {
                                data: 'scholar_name',
                                "render": function (data, type, row) {
                                    return "<div class=\"d-flex flex-column\">" +
                                        // "<span><b>Total: </b>" + formatNumber(row.total) + "</span> " +
                                        "<span><b>Recoverable Amount: </b>" + formatNumber(row.ra_amount) + "</span> " +
                                        "<span><b>Non-Recoverable Amount: </b>" + formatNumber(row.nra_amount) + "</span> " +
                                        "<span><b>LOD Issued: </b>" + formatNumber(row.lod_issued_percentage) + "%</span> " +
                                        "<span><b>LOD Amount: </b>" + formatNumber(row.lod_amount) + "</span> " +
                                        "</div>";
                                }
                            },
                            {
                                data: 'scholar_name',
                                "render": function (data, type, row) {
                                    var _status = "";
                                    if (row.email_status == "RELEASED") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">RELEASED</span>";
                                    if (row.email_status == "UNRELEASED") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-secondary\">UNRELEASED</span>";

                                    return "<div class=\"d-flex flex-column text-center\">" +
                                        "<span class=\"eye-icon btn btn-active-icon-primary btn-text-primary\"><a href=\"Recovery/Memo/Details/View?id=" + row.scholar_nric + "\"><i class=\"far fa-eye fs-2\"></i></a></span>" + 
                                        "<span>" + (_status != "" ? _status : "<i class=\"text-danger\">Email Status not found</i>") + "</span> " +
                                        "</div>";
                                }
                            },
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

function formatNumber(number) {
    return number !== null && number !== undefined && !isNaN(number)
        ? Number(number).toLocaleString('en-US')
        : '<i class="text-danger">Data not found</i>';
}

// Submit Appendix A 
document.getElementById('btn_SAA').onclick = function () {
    Swal.fire({
        title: "SUBMIT APPENDIX A?",
        text: "This action is not reversible!",
        icon: "warning",
        confirmButtonText: 'Confirm',
        showCancelButton: true,
        closeOnConfirm: false,
        customClass: {
            confirmButton: "btn btn-light-primary",
            cancelButton: "btn btn-light-warning"
        }
    }).then(
        function (result) {
            if (result.isConfirmed) {
                const MemoId = new URLSearchParams(window.location.search).get('id');
                const Status = "8afd1063-d42e-4c7d-9d4e-eb34c4c6fe71";
                const Flag = "SAA";
                console.log(MemoId,Status,Flag);

                $.ajax({
                    type: 'post',
                    url: 'Recovery/UpdateMemoStatus',
                    contentType: 'application/json',
                    data: JSON.stringify({ MemoId: MemoId, Status: Status, Flag: Flag }),
                    success: function (response) {
                        Swal.fire({
                            title: "Appendix A Submitted!",
                            text: response.message,
                            icon: "success",
                            customClass: {
                                confirmButton: "btn btn-light-success"
                            }
                        }).then(function () {
                            location.reload();
                        });
                    },
                    error: function (xhr) {
                        Swal.fire({
                            title: "Error",
                            text: xhr.responseJSON.message,
                            icon: "error",
                            customClass: {
                                confirmButton: "btn btn-light-danger"
                            }
                        });
                    }
                })
            }
        }
    );
};

// Upload Memo 
document.getElementById('btn_UM').onclick = function () {
    Swal.fire({
        title: "Upload Memo",
        input: "file",
        inputAttributes: {
            "accept": "pdf/*",
            "aria-label": "Upload Memo"
        }
    });
};

// Download Memo 
document.getElementById('btn_DM').onclick = function () {
    Swal.fire({
        title: "DOWNLOAD MEMO?",
        icon: "question",
        confirmButtonText: 'Download',
        showCancelButton: true,
        customClass: {
            confirmButton: "btn btn-light-primary",
            cancelButton: "btn btn-light-warning",
        }
    }).then(
        function (result) {
            if (result.isConfirmed) {
                function downloadFile(filePath) {
                    var link = document.createElement('a');
                    link.href = filePath;
                    link.download = filePath.substr(filePath.lastIndexOf('/') + 1);
                    link.click();
                }
                downloadFile('assets/storage/dummy.pdf');
                Swal.fire({
                    title: "Memo Downloaded!",
                    icon: "success",
                    customClass: {
                        confirmButton: "btn btn-light-success"
                    }
                });
            }
        }
    );
};

// Approve Appendix A
document.getElementById('btn_AAA').onclick = function () {
    Swal.fire({
        title: "APPROVE APPENDIX A?",
        text: "This action is not reversible!",
        icon: "warning",
        confirmButtonText: 'Confirm',
        showCancelButton: true,
        closeOnConfirm: false,
        customClass: {
            confirmButton: "btn btn-light-primary",
            cancelButton: "btn btn-light-warning"
        }
    }).then(
        function (result) {
            if (result.isConfirmed) {
                const MemoId = new URLSearchParams(window.location.search).get('id');
                const Status = "91c087b5-f10e-457b-a248-bec966f4fd38";
                const Flag = "AAA";

                $.ajax({
                    type: 'post',
                    url: 'Recovery/UpdateMemoStatus',
                    contentType: 'application/json',
                    data: JSON.stringify({ MemoId: MemoId, Status: Status, Flag: Flag }),
                    success: function (response) {
                        Swal.fire({
                            title: "Appendix A Approved!",
                            text: response.message,
                            icon: "success",
                            customClass: {
                                confirmButton: "btn btn-light-success"
                            }
                        }).then(function () {
                            location.reload();
                        });
                    },
                    error: function (xhr) {
                        Swal.fire({
                            title: "Error",
                            text: xhr.responseJSON.message,
                            icon: "error",
                            customClass: {
                                confirmButton: "btn btn-light-danger"
                            }
                        });
                    }
                })
            }
        }
    );
};