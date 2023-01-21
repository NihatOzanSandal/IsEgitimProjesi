using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeviyeBelirlemeIcinETicaret.Models;
using SeviyeBelirlemeIcinETicaret.Models.siniflar;

namespace SeviyeBelirlemeIcinETicaret.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        context c = new context();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GirisYap(Kullanicilar model)
        {
            var webResult = new WebResult();

            var bilgiler = c.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi && x.Sifre == model.Sifre);
            if (bilgiler != null)
            {
                //Jwt token
                Session["KullaniciId"] = bilgiler.ID;
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi;
                //return RedirectToAction("Home", "Home");

                webResult.Type = Enums.WebResult.Redirect;
                webResult.Url = Url.Action("Home", "Home");

                return Json(webResult, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //Response.Write("<script lang='JavaScript'>alert('Kullanıcı Girişi Başarısız Kullanıcı Adınızı ve Şifrenizi Kontrol Edip Lütfen Tekrar Deneyin');</script>");
                //return View();
                webResult.Type = Enums.WebResult.Error;
                webResult.ErrorOccured = true;
                webResult.ErrorMessage = "Kullanıcı Girişi Başarısız Kullanıcı Adınızı ve Şifrenizi Kontrol Edip Lütfen Tekrar Deneyin";
                return Json(webResult, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult YeniHesap()
        {
            ViewBag.Message = "Yeni Hesap Page ";

            return View();
        }
        [HttpPost]
        public ActionResult YeniHesap(Kullanicilar model)
        {
            //var EmailBilgisi = db.Members.FirstOrDefault(x => x.Email == model.Email);
            //var UserNameBilgisi = db.Members.FirstOrDefault(x => x.UserName == model.UserName);

            var KullaniciAdi = c.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == model.KullaniciAdi);
            var Sifre = c.Kullanicilar.FirstOrDefault(x => x.Sifre == model.Sifre);
            if (KullaniciAdi == null)
            {
                if (Sifre == null)
                {
                    c.Kullanicilar.Add(model);
                    c.SaveChanges();
                    Response.Write("<script lang='JavaScript'>alert('Hesap Oluşturma Başarılı) ');</script>");                   
                }
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Hesap Oluşturma Başarısız) ');</script>");
                return View();
            }
            return View("/Views/GirisYap/GirisYap.cshtml");
        }
    }
}