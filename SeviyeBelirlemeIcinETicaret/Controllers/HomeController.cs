using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeviyeBelirlemeIcinETicaret.Models.siniflar;

namespace SeviyeBelirlemeIcinETicaret.Controllers
{
    public class HomeController : Controller
    {
        private context db = new context();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            ViewBag.Message = "Home Page";

            return View(db.Kategori.ToList());
        }

        public ActionResult KategoriyeGoreUrunler(int id)
        {
            ViewBag.Message = "KategoriyeGoreUrunler page.";

            var Varmi = db.Urunler.FirstOrDefault(x => x.KategoriId == id);
            var KategoriUrunuleri = db.Urunler.Where(x => x.KategoriId == id);
            var KategoriAdi = db.Kategori.FirstOrDefault(x => x.ID == id);
            Session["KategoriAdi"] = KategoriAdi.KategoriAdi;
            if (KategoriUrunuleri != null)
            {
                return View(KategoriUrunuleri.ToList());
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Seçtiğiniz Kategori Bulunmamaktadır');</script>");
                return View();
            }
        }
        [HttpPost]
        public ActionResult KategoriyeGoreUrunler(Sepet model)
        {

            if (model.KullaniciId != 0)
            {
                if (model.UrunId != 0)
                {
                    db.Sepet.Add(model);
                    db.SaveChanges();                  
                }
            }
            else
            {
                Response.Write("<script lang='JavaScript'>alert('Sepete Ürün Ekleme Başarısız');</script>");
                return View();
            }
            return RedirectToAction("Sepet", "Home");

            // Burdan Kullanici Id gönderilmeli !!!!
        }

        

        public ActionResult Sepet()
        {
            //int KullaniciId = Session["KullaniciId"];
            var KullaniciUrunleri = ViewBag.Message = "Sepet Page";

            return View(db.Sepet.ToList()); //BURAYI KONTROL ET
        }





    }
}