"use strict";
var KTSigninGeneral = (function () {
    var t, e, r;
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
            (t = document.querySelector("#kt_sign_in_form")),
                (e = document.querySelector("#kt_sign_in_submit")),
                (r = FormValidation.formValidation(t, {
                    fields: {
                        Email: { validators: { regexp: { regexp: /^[^\s@]+@[^\s@]+\.[^\s@]+$/, message: "The value is not a valid email address" }, notEmpty: { message: "Email address is required" } } },
                        Fullname: { validators: { notEmpty: { message: "The full name is required" } } },
                        IdentityNo: { validators: { notEmpty: { message: "The identification no is required" } } },
                        PhoneNo: { validators: { notEmpty: { message: "The phone is required" } } },
                    },
                    plugins: {
                        trigger: new FormValidation.plugins.Trigger(),
                        bootstrap: new FormValidation.plugins.Bootstrap5({ rowSelector: ".fv-row", eleInvalidClass: "", eleValidClass: "" })
                    },
                })),
                !(function (t) {
                    try {
                        return new URL(t), !0;
                    } catch (t) {
                        return !1;
                    }
                })(e.closest("form").getAttribute("action"))
                    ? e.addEventListener("click", function (i) {
                        i.preventDefault(),
                            r.validate().then(function (r) {
                                "Valid" == r
                                    ? (e.setAttribute("data-kt-indicator", "on"),
                                        (e.disabled = !0),
                                        setTimeout(function () {

                                            e.removeAttribute("data-kt-indicator"),
                                                (e.disabled = !1),
                                                Swal.fire({ text: "You have successfully logged in!", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } }).then(
                                                    function (e) {
                                                        if (e.isConfirmed) {
                                                            (t.querySelector('[name="email"]').value = ""), (t.querySelector('[name="password"]').value = "");
                                                            var r = t.getAttribute("data-kt-redirect-url");
                                                            r && (location.href = r);
                                                        }
                                                    }
                                                );
                                            e.disabled = true;
                                            $('#kt_sign_in_form').trigger('submit');
                                        }, 2e3))
                                    : Swal.fire({
                                        text: "Sorry, looks like there are some errors detected, please try again.",
                                        icon: "error",
                                        buttonsStyling: !1,
                                        confirmButtonText: "Ok, got it!",
                                        customClass: { confirmButton: "btn btn-primary" },
                                    });
                            });
                    })
                    : e.addEventListener("click", function (i) {
                        i.preventDefault(),
                            r.validate().then(function (r) {
                                "Valid" == r
                                    ? (e.setAttribute("data-kt-indicator", "on"),
                                        (e.disabled = !0),
                                        axios
                                            .post(e.closest("form").getAttribute("action"), new FormData(t))
                                            .then(function (e) {
                                                if (e) {
                                                    t.reset(),
                                                        Swal.fire({ text: "You have successfully logged in!", icon: "success", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } });
                                                    const e = t.getAttribute("data-kt-redirect-url");
                                                    e && (location.href = e);
                                                } else Swal.fire({ text: "Sorry, the email or password is incorrect, please try again.", icon: "error", buttonsStyling: !1, confirmButtonText: "Ok, got it!", customClass: { confirmButton: "btn btn-primary" } });
                                            })
                                            .catch(function (t) {
                                                Swal.fire({
                                                    text: "Sorry, looks like there are some errors detected, please try again.",
                                                    icon: "error",
                                                    buttonsStyling: !1,
                                                    confirmButtonText: "Ok, got it!",
                                                    customClass: { confirmButton: "btn btn-primary" },
                                                });
                                            })
                                            .then(() => {
                                                e.removeAttribute("data-kt-indicator"), (e.disabled = !1);
                                            }))
                                    : Swal.fire({
                                        text: "Sorry, looks like there are some errors detected, please try again.",
                                        icon: "error",
                                        buttonsStyling: !1,
                                        confirmButtonText: "Ok, got it!",
                                        customClass: { confirmButton: "btn btn-primary" },
                                    });
                            });
                    });
        },
    };
})();
KTUtil.onDOMContentLoaded(function () {
    KTSigninGeneral.init();
});
