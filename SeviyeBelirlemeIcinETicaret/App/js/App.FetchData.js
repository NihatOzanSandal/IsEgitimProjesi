'use strict';
//Callback -> function

var AjaxPost = function (url, model, callbackSucc, callbackFailed = AjaxResults.Failed) {
    $.ajax({
        data: JSON.stringify(model),
        dataType: "json",
        type: "POST",
        url: url,
        contentType: 'application/json; charset=utf-8',
        success: callbackSucc,
        error: callbackFailed,
        timeout: 30000,
        
    });
};


var Logins = {
    Login: function (model) {
        AjaxPost("/GirisYap/GirisYap", model, AjaxResults.LoginSucc)
    }
}
var NewAccounts = {
    NewAccount: function (model) {
        AjaxPost("/GirisYap/YeniHesap", model, AjaxResults.NewAccountSucc)
    }
}


var Products = {
    GetProduct: function () {
        AjaxPost("/Product/Product", {}, LoginSucc);
    },
    GetProduct: function () {
        AjaxPost("/Product/Product", {}, NewAccountSucc);
    }
}

var Baskets = {

}

var Admin = {

}

