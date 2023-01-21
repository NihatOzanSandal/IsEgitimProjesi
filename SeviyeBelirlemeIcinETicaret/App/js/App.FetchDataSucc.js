'use strict';

var AjaxResults = {
    Failed: function (result) {

        if (result.ErrorOccured == true && typeof result.ErrorMessage != 'undefined')
            alert(result.ErrorMessage);
        else
            alert("Geçersiz istek tipi!");
    },
    LoginSucc: function (result) {
        if (result.Type == App.Enums.WebResult.Redirect) {
            window.location = result.Url;
        }
        else if (result.Type == App.Enums.WebResult.Error) {
            alert('Kullanıcı Girişi Başarısız Kullanıcı Adınızı ve Şifrenizi Kontrol Edip Lütfen Tekrar Deneyin');
        }
        else if (result.Type == App.Enums.WebResult.Error) {
            if (result.ErrorOccured == true && typeof result.ErrorMessage != 'undefined')
                alert(result.ErrorMessage);
            else
                alert("Kullanıcı girişi başarısız!");
        }
    },
    StandartResult: function (result) {

    },
}

