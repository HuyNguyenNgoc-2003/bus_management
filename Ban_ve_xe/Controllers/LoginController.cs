using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ban_ve_xe.Models;
using Ban_ve_xe.Common;


namespace Ban_ve_xe.Controllers
{
    public class LoginController : Controller
    {
        private DB_BUSEntities db = new DB_BUSEntities();
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            string pw = Encryptor.MD5Hash(model.Password);
            var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.TaiKhoan.Equals(model.Username) && x.MatKhau.Equals(pw));
            //var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.TaiKhoan.Equals(model.Username) && x.MatKhau.Equals(model.Password));
            if (e != null)
            {
                var user = db.NhanVienVanPhongs.SingleOrDefault(x => x.TaiKhoan.Equals(model.Username));
                var session = new Login();
                session.ID = user.ID;
                session.Username = user.TaiKhoan;
                session.Password = user.MatKhau;
                session.DeptID = (int)user.MaPhongBan;//
                session.DiaChi = user.DiaChi;
                session.DienThoai = user.DienThoai;
                session.SoCMTND = user.SoCMTND;
                session.AnhCaNhan = user.AnhCaNhan;
                session.Name = user.HoTen;
                Session.Add(CommonConstants.SESSION, session);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.SESSION] = null;
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(NhanVienVanPhong cus)
        {
            if (ModelState.IsValid)
            {
                string pw = Encryptor.MD5Hash(cus.MatKhau);
                var check = db.NhanVienVanPhongs.Where(s => s.TaiKhoan == cus.TaiKhoan).FirstOrDefault();
                if (check == null)
                {
                    cus.MatKhau = pw;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.NhanVienVanPhongs.Add(cus);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.ErrorRegister = "Tên tài khoản đã tồn tại";
                }
            }

            return View();
        }


    }
}