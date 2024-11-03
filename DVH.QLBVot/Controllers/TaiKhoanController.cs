using DVH.QLBVot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DVH.QLBVot.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(string tenDangNhap, string matKhau)
        {
            // ktra xem điền chưa tbao theieus ttin
            if(string.IsNullOrEmpty(tenDangNhap) == true | string.IsNullOrEmpty(matKhau))
            {
                ViewBag.thongbao = "Thông báo thiếu thông tin";
                return View();
            }
            // tim tai khaon dang nhap trong database
            var taiKhoan = new Taikhoann().ChiTiet(tenDangNhap);
            // ktra ton tai tai khoan neu khong ton tai => tro ve trang dang nhap
            if (taiKhoan == null)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //ktra mat khau neu sai thi trở vè dâgwd nhap
            if(taiKhoan.MatKhau != matKhau)
            {
                ViewBag.thongbao = "Tài khoản hoặc mật khẩu không đúng";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            // kiem tra active 
            if (taiKhoan.Active != true)
            {
                ViewBag.thongbao = "Tài khoản đang tạm khoá";
                ViewBag.tenDangNhap = tenDangNhap;
                return View();
            }
            //tài khoản đăng nhập: lưu lại 
            Session["user"] = taiKhoan;
            // chuyen sang trang tru admin
            return RedirectToAction("Index", "Admin");
        }
    }
}