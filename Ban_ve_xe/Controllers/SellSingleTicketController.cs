using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;
using System.Data;
using System.Data.Entity;

namespace Ban_ve_xe.Controllers
{
    public class SellSingleTicketController : BaseController//thong tin ban ve ngay
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /SellSingleTicket/
        public ActionResult Index()
        {
            return View(db.BanVeNgays.Include(x => x.PhuXe).Include(x => x.VeNgay).ToList());
        }

        public ActionResult Print()
        {
            return View(db.BanVeNgays.Include(x => x.PhuXe).Include(x => x.VeNgay).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var assistant = db.PhuXes.ToList();
            ViewBag.MaPhuXe = new SelectList(assistant, "MaPhuXe", "HoTen");
            var st = db.VeNgays.ToList();
            ViewBag.MaVeNgay = new SelectList(st, "MaVeNgay", "TenVeNgay");
            return View();
        }
        [HttpPost]
        public ActionResult Create(BanVeNgay e)
        {
            db.BanVeNgays.Add(e);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.PhuXe = db.PhuXes.ToList();
            ViewBag.VeNgay = db.VeNgays.ToList();
            return View(db.BanVeNgays.SingleOrDefault(x => x.MaGiaoDich == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, BanVeNgay sst)
        {
            var e = db.BanVeNgays.SingleOrDefault(x => x.MaGiaoDich == id);
            e.Ngay = sst.Ngay;
            e.MaPhuXe = sst.MaPhuXe;
            e.MaVeNgay = sst.MaVeNgay;
            e.SoVePhatRa = sst.SoVePhatRa;
            e.SoVeThuVe = sst.SoVeThuVe;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.BanVeNgays.SingleOrDefault(x => x.MaGiaoDich == id);
                db.BanVeNgays.Remove(e);
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