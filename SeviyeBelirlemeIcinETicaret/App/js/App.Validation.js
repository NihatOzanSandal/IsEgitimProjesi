var AppForms = {
    FormKeys: {
        LoginForm: "#login-form",
        RegisterForm: "#register-form", //??
        TestLoginForm: "#test-login-form",
        NewAccountForm: "#NewAccount-form"
    },
    ObjectifyForm: function (form) {
        var $form = $(form);

        var disabledInputs = $form.find('input[disabled]').removeAttr('disabled');
        var serializeData = $form.serializeArray();

        disabledInputs.attr('disabled', '');

        var resultObj = {};

        for (var i = 0; i < serializeData.length; i++) {
            var objdata = serializeData[i];
            resultObj[objdata.name] = objdata.value;
        }

        return resultObj;
    },
}

var AppValidation = {
    Validation: {
        LoginForm: {
            FormKey: AppForms.FormKeys.LoginForm,
            Fields: [
                {
                    KullaniciAdi: {
                        Required: true,
                        StringLength: {
                            min: 0,
                            max: 50
                        }
                    },
                    Sifre: {
                        Required: true,
                        StringLength: {
                            min: 0,
                            max: 10
                        }
                    }
                }
            ],
        },
        NewAccountForm: {
            FormKey: AppForms.FormKeys.NewAccountForm,
            Fields: [
                {
                    KullaniciAdi: {
                        Required: true,
                        StringLength: {
                            min: 0,
                            max: 50
                        }
                    },
                    Sifre: {
                        Required: true,
                        StringLength: {
                            min: 0,
                            max: 5
                        }
                    },
                    
                }
            ]
        }
    },

    Init: function () {
        if (this.Validation != null || this.Validation != undefined) {
            var validationkeys = Object.keys(this.Validation);

            $.each(validationkeys, function (index, key) {
                var formkey = AppValidation.Validation[key].FormKey;
                let $form = $(formkey);

                if (formkey != undefined || formkey != null || formkey != '') {
                    $.each(AppValidation.Validation[key].Fields, function (findex, field) {
                        var inputnames = Object.keys(field);

                        $.each(inputnames, function (inpindex, inputname) {
                            var attributes = Object.keys(field[inputname]);
                            let $input = $form.find(`[name="${inputname}"]`);

                            if ($input.length == 0) return;

                            if (typeof attributes.find(item => item == "Required") != 'undefined' && field[inputname].Required == true) {
                                $input.attr('required', '');
                            }

                            if (typeof attributes.find(item => item == "StringLength") != 'undefined' && field[inputname].StringLength != {}) {
                                var min = field[inputname].StringLength.min;
                                var max = field[inputname].StringLength.max;

                                if (min == undefined || min == null) min = 0;

                                if (max != undefined || max != null || max != 0) {
                                    $input.attr('data-parsley-minlength', min);
                                    $input.attr('data-parsley-maxlength', max);
                                }
                            }
                        });

                    });
                }

                $form.attr('data-parsley-validate', '');
            });

            AppValidationSubmit.Init();
        }
    }
}

var AppValidationSubmit = {
    Init: function () {
        // BURAYI DİNAMİK YAPILACAK EKLENİLEN HERBİR SUBMİT OTOMATİK BURAYA EKLENECEK
        //OTOMATİK INIT FONKSİYONUNA EKLEME VEYA INIT GİBİ OTOMATİK ÇALIŞMA ÖZELLİĞİNİ ARAŞTIR

        this.LoginFormSubmit();
        this.NewAccountFormSubmit();
    },

    LoginFormSubmit: function () {
        $(AppForms.FormKeys.LoginForm).parsley()
            .on('field:validated', function () {

            })
            .on('form:submit', function () {
                var model = AppForms.ObjectifyForm(AppForms.FormKeys.LoginForm);
                Logins.Login(model);
                return false;
            }
            );
    },
    // REGİSTER KISMI YAPILACAK VE SAYFADAKİ TÜM RAZOR PAGE YNLENDİRMELERİ İPTAL EDİLİP BURDAKİ YAPIYUA AKTIRALACAK
    // SEPET DAHİL BU MEKANİZMALAR JS TARAFINDAN ÇALIŞTIRILACAK
    NewAccountFormSubmit: function () {//   Yeni Hesap 
        $(AppForms.FormKeys.NewAccountForm).parsley()
            .on('field:validated', function () {

            })
            .on('form:submit', function () {
                var model = AppForms.ObjectifyForm(AppForms.FormKeys.NewAccountForm);
                NewAccounts.NewAccount(model);
                return false;
            }
            );
    }

}

