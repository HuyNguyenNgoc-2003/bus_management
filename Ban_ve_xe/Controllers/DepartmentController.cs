using Ban_ve_xe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ban_ve_xe.Controllers
{
    public class DepartmentController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View(db.PhongBans.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhongBan dept)
        {
            db.PhongBans.Add(dept);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.PhongBans.SingleOrDefault(x => x.MaPhongBan == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, PhongBan dept)
        {
            var e = db.PhongBans.Where(x => x.MaPhongBan == id).SingleOrDefault();
            e.TenPhongBan = dept.TenPhongBan;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }
	}
}