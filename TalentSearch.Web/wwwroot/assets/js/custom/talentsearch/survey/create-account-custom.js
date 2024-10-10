"use strict";
var KTCreateAccount = (function () {
    var e, // kt_modal_create_account
        t, // kt_create_account_stepper
        i, // kt_create_account_form
        o, // data-kt-stepper-action="submit"]
        a, // data-kt-stepper-action="next"]
        r, // kt.stepper.changed
        s = []; // getCurrentStepIndex
    return {
        init: function () {
            (Inputmask({
                mask: "[*{1,250}]",
                onBeforePaste: function (a, t) {
                    return (a = a.toUpperCase())
                },
                definitions: {
                    "*": {
                        cardinality: 1,
                        casing: "upper"
                    }
                }
            }).mask("#Fullname")),
                (Inputmask({
                    mask: "999999-99-9999"
                }).mask("#IdentityNo")),
                (Inputmask({
                    mask: "+60[9{1,2}]-[9{1,8}]"
                }).mask("#PhoneNo")),
                Inputmask({
                    mask: "*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}][@{1,1}]*{1,20}[.*{2,6}][.*{1,2}]", //"*{1,20}[.*{1,20}][.*{1,20}][.*{1,20}]@*{1,20}[.*{2,6}][.*{1,2}]"
                    greedy: !1,
                    onBeforePaste: function (a, t) {
                        return (a = a.toLowerCase()).replace("mailto:", "")
                    },
                    definitions: {
                        "*": {
                            validator: '[0-9A-Za-z!#$%&"*+/=?^_`{|}~-]',
                            cardinality: 1,
                            casing: "lower"
                        }
                    }
                }).mask("#Email"),
                (e = document.querySelector("#kt_modal_create_account")) && new bootstrap.Modal(e),
                (t = document.querySelector("#kt_create_account_stepper")) &&
                ((i = t.querySelector("#kt_create_account_form")),
                    (o = t.querySelector('[data-kt-stepper-action="submit"]')),
                    (a = t.querySelector('[data-kt-stepper-action="next"]')),
                    (r = new KTStepper(t)).on("kt.stepper.changed", function (e) {
                        5 === r.getCurrentStepIndex()
                            ? (o.classList.remove("d-none"), o.classList.add("d-inline-block"), a.classList.add("d-none"))
                            : 6 === r.getCurrentStepIndex()
                                ? (o.classList.add("d-none"), a.classList.add("d-none"))
                                : (o.classList.remove("d-inline-block"), o.classList.remove("d-none"), a.classList.remove("d-none"));
                    }),
                    r.on("kt.stepper.next", function (e) {
                        var t = s[e.getCurrentStepIndex() - 1];
                        t
                            ? t.validate().then(function (t) {
                                console.log("validated form " + e.getCurrentStepIndex() + "!"),
                                    "Valid" == t
                                        ? (e.goNext(), KTUtil.scrollTop())
                                        : Swal.fire({
                                            text: "Sorry, looks like there are some errors detected, please try again.",
                                            icon: "error",
                                            buttonsStyling: !1,
                                            confirmButtonText: "Ok, got it!",
                                            customClass: { confirmButton: "btn btn-light" },
                                        }).then(function () {
                                            KTUtil.scrollTop();
                                        });
                            })
                            : (e.goNext(), KTUtil.scrollTop());
                    }),
                    r.on("kt.stepper.previous", function (e) {
                        console.log("stepper.previous"), e.goPrevious(), KTUtil.scrollTop();
                    }),
                    s.push(
                        FormValidation.formValidation(i, {
                            fields: {
                                Email: { validators: { regexp: { regexp: /^[^\s@]+@[^\s@]+\.[^\s@]+$/, message: "The value is not a valid email address" }, notEmpty: { message: "Email address is required" } } },
                                Fullname: { validators: { notEmpty: { message: "The full name is required" } } },
                                IdentityNo: { validators: { notEmpty: { message: "The identification no is required" } } },
                                PhoneNo: { validators: { notEmpty: { message: "The phone is required" } } },
                            },
                            plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) },
                        })
                ),
                s.push(
                    FormValidation.formValidation(i, {
                        fields: {
                            Q1: { validators: { notEmpty: { message: "Question is required" } } },
                            Q2: { validators: { notEmpty: { message: "Question is required" } } }
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) },
                    })
                ),
                s.push(
                    FormValidation.formValidation(i, {
                        fields: {
                            Q3: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q4: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q5: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q6: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q7: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q8: { validators: { notEmpty: { message: "Question is required" } } },
                            //Q9: { validators: { notEmpty: { message: "Question is required" } } },

                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) },
                    })
                ),
                s.push(
                    FormValidation.formValidation(i, {
                        fields: {
                            Q10: { validators: { notEmpty: { message: "Question is required" } } }
                        },
                        plugins: { trigger: new FormValidation.plugins.Trigger(), bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" }) },
                    })
                ),
                o.addEventListener("click", function (e) {
                    console.log(r.getCurrentStepIndex());
                    if (r.getCurrentStepIndex() == 2)
                        s[1].validate().then(function (t) {
                            console.log("validated All!"),
                                "Valid" == t
                                    ? (e.preventDefault(),
                                        (o.disabled = !0),
                                        o.setAttribute("data-kt-indicator", "on"),
                                        setTimeout(function () {
                                            o.removeAttribute("data-kt-indicator"), (o.disabled = !1);//, r.goNext();
                                            o.disabled = true;
                                            $('#kt_create_account_form').trigger('submit');
                                            Swal.fire({
                                                text: "Your survey has been submitted",
                                                icon: "success",
                                                buttonsStyling: !1,
                                                confirmButtonText: "Ok, got it!",
                                                customClass: { confirmButton: "btn btn-light btn-light-warning" },
                                            });
                                        }, 2e3))
                                    : Swal.fire({
                                        text: "Sorry, looks like there are some errors detected, please try again.",
                                        icon: "error",
                                        buttonsStyling: !1,
                                        confirmButtonText: "Ok, got it!",
                                        customClass: { confirmButton: "btn btn-light" },
                                    }).then(function () {
                                        KTUtil.scrollTop();
                                    });
                        });
                    else if (r.getCurrentStepIndex() == 5)
                        s[3].validate().then(function (t) {
                            console.log("validated All!"),
                                "Valid" == t
                                    ? (e.preventDefault(),
                                        (o.disabled = !0),
                                        o.setAttribute("data-kt-indicator", "on"),
                                        setTimeout(function () {
                                            o.removeAttribute("data-kt-indicator"), (o.disabled = !1);//, r.goNext();
                                            o.disabled = true;
                                            $('#kt_create_account_form').trigger('submit');
                                            Swal.fire({
                                                text: "Your survey has been submitted",
                                                icon: "success",
                                                buttonsStyling: !1,
                                                confirmButtonText: "Ok, got it!",
                                                customClass: { confirmButton: "btn btn-light btn-light-warning" },
                                            });
                                        }, 2e3))
                                    : Swal.fire({
                                        text: "Sorry, looks like there are some errors detected, please try again.",
                                        icon: "error",
                                        buttonsStyling: !1,
                                        confirmButtonText: "Ok, got it!",
                                        customClass: { confirmButton: "btn btn-light" },
                                    }).then(function () {
                                        KTUtil.scrollTop();
                                    });
                        });
                }),
                $(i.querySelector('[name="Q2"]')).on("change", function () {
                    if ($(this).val() == 'Yes') {
                        5 === r.getCurrentStepIndex()
                            ? (o.classList.remove("d-none"), o.classList.add("d-inline-block"), a.classList.add("d-none"))
                            : 6 === r.getCurrentStepIndex()
                                ? (o.classList.add("d-none"), a.classList.add("d-none"))
                                : (o.classList.remove("d-inline-block"), o.classList.remove("d-none"), a.classList.remove("d-none"));
                    }
                    else if ($(this).val() == 'No') {
                        console.log(r.getCurrentStepIndex());
                        r.getCurrentStepIndex()
                            ? (o.classList.remove("d-none"), o.classList.add("d-inline-block"), a.classList.add("d-none"))
                            : 6 === r.getCurrentStepIndex()
                                ? (o.classList.add("d-none"), a.classList.add("d-none"))
                                : (o.classList.remove("d-inline-block"), o.classList.remove("d-none"), a.classList.remove("d-none"));
                    }
                }),
                $(i.querySelector('[name="Q3"]')).on("change", function () {
                    $("#FQ4").hide(), $("#FQ5").hide(), $("#FQ6").hide(), $("#FQ7").hide(), $("#FQ8").hide(), $("#FQ8_1").hide(), $("#FQ9").hide();
                    
                    if ($(this).val() == 'Employed') {
                        $("#FQ4").show(), $("#FQ5").hide(), $("#FQ6").hide(), $("#FQ7").show(), $("#FQ8").show(), $("#FQ8_1").hide(),  $("#FQ9").show();
                    }
                    else if ($(this).val() == 'Self-Employed') {
                        $("#FQ4").hide(), $("#FQ5").show(), $("#FQ6").show(), $("#FQ7").hide(), $("#FQ8").hide(), $("#FQ8_1").hide(), $("#FQ9").hide();
                    }
                }),
                $(i.querySelector('[name="Q10"]')).on("change", function () {
                    $("#FQ11_1").hide(), $("#FQ11_1R").hide(),$("#FQ11_1RT").hide(), $("#FQ11_2").hide(), $("#FQ11_2R").hide(), $("#FQ11_2RT").hide(), $("#FQ11_3").hide(), $("#FQ11_3R").hide(), $("#FQ11_3RT").hide(),$("#FQ12").hide(), $("#FQ12_1").hide(), $("#FQ12_1R").hide(), $("#FQ12_2").hide(), $("#FQ12_2R").hide(), $("#FQ12_3").hide(), $("#FQ12_3R").hide(), $("#FQ12_4").hide(), $("#FQ12_4R").hide(), $("#FQ12_5").hide(), $("#FQ12_5R").hide(), $("#FQ12_6").hide(), $("#FQ12_6R").hide() ;
                    
                    if ($(this).val() == 'Business') {
                        $("#FQ11_1").show(), $("#FQ11_1R").show(), $("#FQ11_1RT").show(), $("#FQ11_2").hide(), $("#FQ11_2R").hide(), $("#FQ11_2RT").hide(), $("#FQ11_3").hide(), $("#FQ11_3R").hide(), $("#FQ11_3RT").hide(),$("#FQ12").show(), $("#FQ12_1").show(), $("#FQ12_1R").show(), $("#FQ12_2").show(), $("#FQ12_2R").show(), $("#FQ12_3").show(), $("#FQ12_3R").show(), $("#FQ12_4").show(), $("#FQ12_4R").show(), $("#FQ12_5").show(), $("#FQ12_5R").show(), $("#FQ12_6").show(), $("#FQ12_6R").show();
                    }
                    else if ($(this).val() == 'Community') {
                        $("#FQ11_1").hide(), $("#FQ11_1R").hide(), $("#FQ11_1RT").hide(), $("#FQ11_2").show(), $("#FQ11_2R").show(), $("#FQ11_2RT").show(), $("#FQ11_3").hide(), $("#FQ11_3R").hide(), $("#FQ11_3RT").hide(),$("#FQ12").show(), $("#FQ12_1").show(), $("#FQ12_1R").show(), $("#FQ12_2").show(), $("#FQ12_2R").show(), $("#FQ12_3").show(), $("#FQ12_3R").show(), $("#FQ12_4").show(), $("#FQ12_4R").show(), $("#FQ12_5").show(), $("#FQ12_5R").show(), $("#FQ12_6").show(), $("#FQ12_6R").show() ;
                    }
					else if ($(this).val() == 'Professional') {
                        $("#FQ11_1").hide(), $("#FQ11_1R").hide(), $("#FQ11_1RT").hide(), $("#FQ11_2").hide(), $("#FQ11_2R").hide(), $("#FQ11_2RT").hide(), $("#FQ11_3").show(), $("#FQ11_3R").show(), $("#FQ11_3RT").show(),$("#FQ12").show(), $("#FQ12_1").show(), $("#FQ12_1R").show(), $("#FQ12_2").show(), $("#FQ12_2R").show(), $("#FQ12_3").show(), $("#FQ12_3R").show(), $("#FQ12_4").show(), $("#FQ12_4R").show(), $("#FQ12_5").show(), $("#FQ12_5R").show(), $("#FQ12_6").show(), $("#FQ12_6R").show() ;
                    }
                }),
                $(i.querySelector('[name="Q14"]')).on("change", function () {
                    $("#FQ15").hide(), $("#FQ16").hide(), $("#FQ17").hide();
                    
                    if ($(this).val() == 'Businesss_leader') {
					
                        $("#FQ15").show(), $("#FQ16").hide(), $("#FQ17").hide();
                    }
                    else if ($(this).val() == 'Community_leader') {
                        $("#FQ15").hide(), $("#FQ16").show(), $("#FQ17").hide();
                    }
					else if ($(this).val() == 'Professional') {
                        $("#FQ15").hide(), $("#FQ16").hide(), $("#FQ17").show();
                    }
                }),
                $(i.querySelector('[name="Q13"]')).on("change", function () {
                    if ($(this).val() == 'Yes') {
                        5 === r.getCurrentStepIndex()
                            ? (o.classList.remove("d-none"), o.classList.add("d-inline-block"), a.classList.add("d-none"))
                            : 6 === r.getCurrentStepIndex()
                                ? (o.classList.add("d-none"), a.classList.add("d-none"))
                                : (o.classList.remove("d-inline-block"), o.classList.remove("d-none"), a.classList.remove("d-none"));
                    }
                    else if ($(this).val() == 'No') {
                        console.log(r.getCurrentStepIndex());
                        r.getCurrentStepIndex()
                            ? (o.classList.remove("d-none"), o.classList.add("d-inline-block"), a.classList.add("d-none"))
                            : 6 === r.getCurrentStepIndex()
                                ? (o.classList.add("d-none"), a.classList.add("d-none"))
                                : (o.classList.remove("d-inline-block"), o.classList.remove("d-none"), a.classList.remove("d-none"));
                    }
                }));
        },
    };
})();
KTUtil.onDOMContentLoaded(function () {
    KTCreateAccount.init();
});
