using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;

namespace Ban_ve_xe.Controllers
{
    public class OfficerController : BaseController
    {
        private DB_BUSEntities db = new DB_BUSEntities();

        // GET: /Officer/
        public ActionResult Index()
        {
            var nhanvienvanphongs = db.NhanVienVanPhongs.Include(n => n.PhongBan);
            return View(nhanvienvanphongs.ToList());
        }

        public ActionResult Print()
        {
            var nhanvienvanphongs = db.NhanVienVanPhongs.Include(n => n.PhongBan);
            return View(nhanvienvanphongs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var dept = db.PhongBans.ToList();
            ViewBag.MaPhongBan = new SelectList(dept, "MaPhongBan", "TenPhongBan");
            return View();
        }

        [HttpPost]
        public ActionResult Create(NhanVienVanPhong entity, bool gender)
        {
            entity.GioiTinh = gender;
            entity.MatKhau = Ban_ve_xe.Common.Encryptor.MD5Hash(entity.MatKhau.ToString());
            db.NhanVienVanPhongs.Add(entity);
            db.SaveChanges();
            TempData["ThongBao"] = "Them moi thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dept = db.PhongBans.ToList();//entity
            return View(db.NhanVienVanPhongs.SingleOrDefault(x => x.ID == id));
        }

        [HttpPost]
        public ActionResult Edit(NhanVienVanPhong entity)
        {
            var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.ID == entity.ID);
            e.HoTen = entity.HoTen;
            e.NgaySinh = entity.NgaySinh;
            e.GioiTinh = entity.GioiTinh;
            e.DiaChi = entity.DiaChi;
            e.DienThoai = entity.DienThoai;
            e.SoCMTND = entity.SoCMTND;
            e.BangCap = entity.BangCap;
            e.MaPhongBan = entity.MaPhongBan;
            db.SaveChanges();
            TempData["ThongBao"] = "Sua thanh cong!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                var entity = db.NhanVienVanPhongs.Where(x => x.ID == id).SingleOrDefault();
                db.NhanVienVanPhongs.Remove(entity);
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
