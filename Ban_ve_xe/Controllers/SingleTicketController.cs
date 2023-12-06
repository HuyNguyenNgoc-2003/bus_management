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
    public class SingleTicketController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /SingleTicket/
        public ActionResult Index()
        {
            return View(db.VeNgays.Include(x => x.TuyenXe).ToList());
        }

        public ActionResult Print()
        {
            return View(db.VeNgays.Include(x => x.TuyenXe).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var busroute = db.TuyenXes.ToList();
            ViewBag.MaTuyenXe = new SelectList(busroute, "MaTuyenXe", "TenTuyenXe");
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeNgay e)
        {
            var rs = db.VeNgays.FirstOrDefault(x => x.TenVeNgay == e.TenVeNgay.Trim());
            if(rs == null)
            {
                db.VeNgays.Add(e);
                db.SaveChanges();
                TempData["ThongBao"] = "Them moi thanh cong!";
            }
            else
            {
                TempData["ThongBao"] = "Ve ngay nay da co!";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, VeNgay st)
        {
            var e = db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id);
            e.TenVeNgay = st.TenVeNgay;
            e.DonGia = st.DonGia;
            e.MaTuyenXe = st.MaTuyenXe;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var e = db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id);
                db.VeNgays.Remove(e);
                db.SaveChanges();
            }
            catch {
                TempData["ThongBao"] = "Xoa khong thanh cong!";
            }
            TempData["ThongBao"] = "Xoa thanh cong!";
            return RedirectToAction("Index");
        }
	}
}