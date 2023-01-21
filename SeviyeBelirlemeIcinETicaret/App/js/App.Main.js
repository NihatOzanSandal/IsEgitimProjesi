var App = {
    Enums: {
        WebResult: {
            NotSet: -1,
            Error: 1,
            Redirect: 2
        }
    }
}



//$(document).ready(function () {
//    // en son çalışır
//    // jquery
//})


window.onload = function () {
    // her zaman ilk çalışır
    // js

    if (typeof AppValidation != 'undefined') {
        try {
            AppValidation.Init();
        } catch (e) { console.log("AppValidation.Init doesnt run!"); }
    }

    if (typeof AppSecurity != 'undefined') {
        try {
            AppSecurity.Init();
        } catch (e) { console.log("AppSecurity.Init doesnt run!"); }
    }

    //$(AppForms.FormKeys.LoginForm).parsley().on('form:submit', function () {
    //    return false;
    //});
}

