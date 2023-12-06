using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;
using System.Data.Entity;

namespace Ban_ve_xe.Controllers
{
    public class BusRouteController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /Buses/
        public ActionResult Index()
        {
            ViewBag.XeBuyt = db.XeBuyts.ToList();
            return View(db.TuyenXes.ToList());
        }

        public ActionResult Print()
        {
            return View(db.TuyenXes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TuyenXe e)
        {
            db.TuyenXes.Add(e);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, TuyenXe e)
        {
            var entity = db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id);
            entity.TenTuyenXe = e.TenTuyenXe;
            entity.GioBatDau = e.GioBatDau;
            entity.GioKetThuc = e.GioKetThuc;
            entity.DiemCuoi = e.DiemCuoi;
            entity.DiemDau = e.DiemDau;
            entity.ChiTietTram = e.ChiTietTram;
            db.SaveChanges();
       
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id);
                db.TuyenXes.Remove(e);
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