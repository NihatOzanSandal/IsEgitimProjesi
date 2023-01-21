var AppSecurity = {
    Inputs: [
        { Parent: AppForms.FormKeys.LoginForm, Id: '#KullaniciAdi', Name: 'KullaniciAdi', ToUpper: false, ToLower: false, Numeric: false, IsAlphabetic: true, IsCopied: false, IsPasted: false },
        { Parent: AppForms.FormKeys.LoginForm, Name: 'Sifre', ToUpper: false, ToLower: false, IsNumeric: true, IsAlphabetic: false, IsCopied: false, IsPasted: false },
        { Parent: AppForms.FormKeys.TestLoginForm, Name: 'KullaniciAdi', ToUpper: true, ToLower: false, IsNumeric: false, IsAlphabetic: true, IsCopied: false, IsPasted: false },
    ],

    ToUpper: function (e) {
        if (!/[\p{L}\s]/u.test(e.key)) {
            return false;
        }

        e.currentTarget.value += e.key.toUpperCase();
        //e.currentTarget.value = e.currentTarget.value.toUpperCase();
        return false;
    },

    ToLower: function (e) {
        if (!/[\p{L}\s]/u.test(e.key)) {
            return false;
        }

        e.currentTarget.value += e.key.toLowerCase();
        //e.currentTarget.value = e.currentTarget.value.toLowerCase();
        return false;
    },

    OnlyNumeric: function (e) {
        //var charCode = e.keyCode;
        //if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        //  return false;
        //}
        //return true;
        return $.isNumeric(e.key);
    },

    OnlyAlphabetic: function (e) {
        if (!/[\p{L}\s]/u.test(e.key)) {
            return false;
        }

        return true;
    },

    RestrictedCopy: function ($target) {
        $target.on('copy', function () {
            return false;
        })
    },

    RestrictedPaste: function ($target) {
        $target.on('paste', function () {
            return false;
        })
    },

    Init: function () {
        $.each(AppSecurity.Inputs, function (index, row) {
            //string literal
            var $target = AppSecurity.GetInputElement(row);

            if ($target == null) return;

            // row = value
            if (row.ToLower && !row.ToUpper) {
                // event keypress, click

                $target.on('keypress', function (e) {
                    return AppSecurity.ToLower(e);
                })
            }

            if (row.ToUpper && row.ToLower == false) {
                $target.on('keypress', function (e) {
                    return AppSecurity.ToUpper(e);
                })
            }

            if (row.IsNumeric && !row.IsAlphabetic) {
                $target.on('keypress', function (e) {
                    return AppSecurity.OnlyNumeric(e);
                })
            }

            if (row.IsAlphabetic && !row.IsNumeric) {
                $target.on('keypress', function (e) {
                    return AppSecurity.OnlyAlphabetic(e);
                })
            }

            if (row.IsCopied == false) {
                AppSecurity.RestrictedCopy($target);
            }

            if (row.IsPasted == false) {
                AppSecurity.RestrictedPaste($target);
            }
            
        });
    },

    GetInputElement(inputModel) {
        if (typeof inputModel == 'undefined' || inputModel == null || inputModel == {}) return null;
        if (inputModel.Parent == null || typeof inputModel.Parent == 'undefined' || inputModel.Parent == '') return null;

        if (typeof inputModel.Name == 'undefined' || inputModel.Name == null) return null;

        if (typeof inputModel.Id == 'undefined' || inputModel.Id == null) inputModel.Id = '';

        var $target = $(inputModel.Parent).find(`input${inputModel.Id}[name="${inputModel.Name}"]`);

        if ($target.length > 1) return null;
        else return $target;
    }
}