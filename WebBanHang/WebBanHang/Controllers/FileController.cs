using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHang.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }

        public FileResult Download(string _FileName)
        {
            var _NoiLuuFileDownload = "~/DocumentFile/" + _FileName;
            return File(_NoiLuuFileDownload, "application/force-download", Path.GetFileName(_NoiLuuFileDownload));
        }
    }
}