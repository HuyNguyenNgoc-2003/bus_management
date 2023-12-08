using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;

namespace Ban_ve_xe.Controllers
{
    public class TicketOfficeController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /TicketOffice/
        public ActionResult Index()
        {
            return View(db.DiemBanVeThangs.ToList());
        }

        public ActionResult Print()
        {
            return View(db.DiemBanVeThangs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiemBanVeThang tkof)
        {
            db.DiemBanVeThangs.Add(tkof);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, DiemBanVeThang tkof)
        {
            var e = db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id);
            e.DiaChi = tkof.DiaChi;
            e.SoDienThoai = tkof.SoDienThoai;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id);
                db.DiemBanVeThangs.Remove(e);
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