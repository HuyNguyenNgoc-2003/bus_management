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
    public class MonthTicketController : BaseController
    {
        DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /MonthTicket/
        public ActionResult Index()
        {
            return View(db.VeThangs.ToList());
        }

        public ActionResult Print()
        {
            return View(db.VeThangs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeThang e)
        {
            db.VeThangs.Add(e);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.VeThangs.SingleOrDefault(x => x.MaVeThang == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, VeThang st)
        {
            var e = db.VeThangs.SingleOrDefault(x => x.MaVeThang == id);
            e.TenVeThang = st.TenVeThang;
            e.DonGia = st.DonGia;
            e.GhiChu = st.GhiChu;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.VeThangs.SingleOrDefault(x => x.MaVeThang == id);
                db.VeThangs.Remove(e);
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