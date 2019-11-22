using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class PageController : Controller
    {
        public ActionResult Index()
        {
            //List<products> lstProduct = new List<products>();

            // Lấy dữ liệu danh sách Sản phẩm
            //lstProduct = DataProvider.Ins.DB.products.ToList(); // SELECT * FROM products

            // Truyền dữ liệu từ Controller -> View thông qua ViewBag
            ViewBag.DanhSachSanPham = DataProvider.Ins.DB.products.ToList();

            return View();
        }

        public ActionResult GioiThieu()
        {
            ViewBag.Message = "Trang giới thiệu";

            return View();
        }

        public ActionResult LienHe()
        {
            ViewBag.Message = "Trang liên hệ";

            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        public ActionResult DangKy()
        {
            return View();
        }
    }
}