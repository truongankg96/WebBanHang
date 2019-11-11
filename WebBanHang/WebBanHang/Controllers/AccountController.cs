using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {
      public ActionResult DangNhap()
        {
            return View();
        }
    }
}