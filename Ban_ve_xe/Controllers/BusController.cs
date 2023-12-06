using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;
using System.Data.Entity;


namespace Ban_ve_xe.Controllers
{
    public class BusController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /Bus/
        public ActionResult Index()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.XeBuyts.ToList());
        }

        public ActionResult Print()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.XeBuyts.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var busroute = db.TuyenXes.ToList();
            ViewBag.MaTuyenXe = new SelectList(busroute, "MaTuyenXe", "TenTuyenXe");
            return View();
        }

        [HttpPost]
        public ActionResult Create(XeBuyt e)
        {
            db.XeBuyts.Add(e);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.XeBuyts.SingleOrDefault(x => x.MaXeBuyt == id));
        }
        [HttpPost]
        public ActionResult Edit(int id, XeBuyt bus)
        {
            var e = db.XeBuyts.SingleOrDefault(x => x.MaXeBuyt == id);
            e.BienKiemSoat = bus.BienKiemSoat;
            e.NamSanXuat = bus.NamSanXuat;
            e.HangSanXuat = bus.HangSanXuat;
            e.SoGhe = bus.SoGhe;
            e.MaTuyenXe = bus.MaTuyenXe;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.XeBuyts.SingleOrDefault(x => x.MaXeBuyt == id);
                db.XeBuyts.Remove(e);
                db.SaveChanges();
            }
            catch
            {
                TempData["ThongBao"] = "Xoa khong thanh cong!";
            }
            TempData["ThongBao"] = "Xoa thanh cong!";
            return RedirectToAction("Index");
        }
	}
}