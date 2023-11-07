using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OgrencıNotMvc.Models.EntityFramework;
               

namespace OgrencıNotMvc.Controllers
{
    public class OgrencıController : Controller
    {
        // GET: Ogrenci
        DbMvcOkulEntities db = new DbMvcOkulEntities();
        public ActionResult Index()
        {
            var ogrenciler = db.TBLOGRENCILER.ToList();
            return View(ogrenciler);
        }

        [HttpGet]
        public ActionResult YeniOgrenci()
        {






            return View();

        }
        [HttpPost]
        public ActionResult YeniOgrenci(TBLOGRENCILER P3)
        {

            var klp = db.TBLKULUPLER.Where(m => m.KULUPID == P3.TBLKULUPLER.KULUPID).FirstOrDefault();
            P3.TBLKULUPLER = klp;
            db.TBLOGRENCILER.Add(P3);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult Sil(int id)
        {
            var ogrenci = db.TBLOGRENCILER.Find(id);
            db.TBLOGRENCILER.Remove(ogrenci);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}