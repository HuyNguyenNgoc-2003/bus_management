using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;
using System.Data.Entity;

namespace Ban_ve_xe.Controllers
{
    public class AssistantController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /Assistant/
        public ActionResult Index()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.PhuXes.ToList());
        }

        public ActionResult Print()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.PhuXes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var busroute = db.TuyenXes.ToList();
            ViewBag.MaTuyenXe = new SelectList(busroute, "MaTuyenXe", "TenTuyenXe");
            return View();
        }
        [HttpPost]
        public ActionResult Create(PhuXe e, bool gender)
        {
            e.GioiTinh = gender;
            db.PhuXes.Add(e);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.PhuXes.SingleOrDefault(x => x.MaPhuXe == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, PhuXe driver)
        {
            var e = db.PhuXes.SingleOrDefault(x => x.MaPhuXe == id);
            e.HoTen = driver.HoTen;
            e.NgaySinh = driver.NgaySinh;
            e.GioiTinh = driver.GioiTinh;
            e.DiaChi = driver.DiaChi;
            e.DienThoai = driver.DienThoai;
            e.SoCMTND = driver.SoCMTND;
            e.MaTuyenXe = driver.MaTuyenXe;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.PhuXes.SingleOrDefault(x => x.MaPhuXe == id);
                db.PhuXes.Remove(e);
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