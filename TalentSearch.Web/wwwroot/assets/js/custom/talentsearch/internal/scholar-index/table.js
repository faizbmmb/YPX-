"use strict";
// Add event listener for opening and closing details


var KTUsersList = (function () {
    var e,
        t,
        n,
        r,
        o = document.getElementById("kt_table_scholars"),
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
                            url: 'http://localhost:5101/api/Datawarehouses/Datawarehouses/GetScholarByAllDataTables',
                            type: 'POST'
                        },
                        columns: [
                            {
                                "data": "sch_name",
                                "render": function (data, type, row) {
                                    return "<div class='form-check form-check-sm form-check-custom form-check-solid'><input class='form-check-input' type='checkbox' value='1' /></div>";
                                }
                            },
                            {
                                data: 'sch_name',
                                "render": function (data, type, row) {
                                    var isMale = (row.sch_nric_new.charAt(row.sch_nric_new.length - 1) % 2 == 0) ? "danger" : "info";
                                    
                                    return "<div class=\"symbol symbol-50px overflow-hidden me-3\">" +
                                        "<a href=\"Internal/Scholar/Details/Overview?Id=" + row.sch_nric_new + "\"><div class=\"symbol-label fs-3 bg-light-" + isMale + " text-" + isMale +"\">" + row.sch_name.substring(0, 1) + "</div></a>"
                                        "</div>";
                                }
                            },
                            {
                                data: 'sch_name',
                                "render": function (data, type, row) {
                                    var _status = "";
                                    if (row.sch_prog_status == "UNKNOWN") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-warning\">UNKNOWN</span>";
                                    if (row.sch_prog_status == "COMPLETED") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-primary\">COMPLETED</span>";
                                    if (row.sch_prog_status == "ACTIVE") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">ACTIVE</span>";
                                    if (row.sch_prog_status == "TERMINATED") _status = "<span class=\"badge py-3 px-4 fs-7 badge-light-danger\">TERMINATED</span>";

                                    return "<div class=\"d-flex flex-column\">" +
                                        "<a href=\"Internal/Scholar/Details/Overview?Id=" + row.sch_nric_new + "\" class=\"text-gray-800 text-hover-warning mb-1\"><b>" + row.sch_name + "</b> (" + row.sch_nric_new + ")</a>" +
                                        "<span>" + (row.sch_email != null ? row.sch_email.toLowerCase() : "<i class=\"text-danger\">Email not found</i>") + "</span>" +
                                        "<span>" + (row.sch_mobile_num != null ? row.sch_mobile_num.toLowerCase() : "<i class=\"text-danger\">Mobile phone not found</i>") + "</span>" +
                                        "<span>" + (_status != "" ? _status : "<i class=\"text-danger\">Scholar status not found</i>") + "</span>" +
                                        "</div>";
                                }
                            },
                            {
                                data: 'main_thrust',
                                "render": function (data, type, row) {
                                    var isMale = (data.charAt(data.length - 1) % 2 == 0) ? false : true;
                                    return "<div class=\"d-flex flex-column\">" +
                                        "<span><b>Thrust: </b>" + (row.main_thrust != null ? row.main_thrust : "<i class=\"text-danger\">Thrust not found</i>") + 
                                        ", <b>Sub Thrust: </b>" + (row.sub_thrust != null ? row.sub_thrust : "<i class=\"text-danger\">Sub thrust not found</i>") + "</span>" +
                                        "<span><b>Programme Name: </b>" + (row.prog_name != null ? row.prog_name : "<i class=\"text-danger\">Programme not found</i>") + "</span> " +
                                        "<span><b>Programme Entry: </b>" + (row.program_entry != null ? row.program_entry : "<i class=\"text-danger\">Program entry not found</i>") + "</span> " +
                                        "</div>";
                                }
                            },
                            {
                                data: 'sch_prog_status',
                                "render": function (data, type, row) {
                                    var _status_prog = "";
                                    if (row.programme_status == "COMPLETED") _status_prog = "<span class=\"badge py-3 px-4 fs-7 badge-light-primary\">COMPLETED</span>";
                                    if (row.programme_status == "ACTIVE") _status_prog = "<span class=\"badge py-3 px-4 fs-7 badge-light-success\">ACTIVE</span>";

                                    return "<div class=\"d-flex flex-column\">" +
                                        "<span><b>Programme Status: </b>" + (_status_prog != "" ? _status_prog : "<i class=\"text-danger\">Programme status not found</i>") + "</span>" +
                                        "<span><b>Contract Start: </b>" + (row.contract_start != null ? row.contract_start : "<i class=\"text-danger\">Contract start not found</i>") + "</span>" +
                                        "<span><b>Contract End: </b>" + (row.contract_end != null ? row.contract_end : "<i class=\"text-danger\">Contract end not found</i>") + "</span>" +
                                        "</div>";
                                }
                            },
                            {
                                data: 'amt_w_gst',
                                "render": function (data, type, row) {
                                    return "RM " + data.toFixed(2).replace(/\d(?=(\d{3})+\.)/g, '$&,');
                                }
                            }
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
