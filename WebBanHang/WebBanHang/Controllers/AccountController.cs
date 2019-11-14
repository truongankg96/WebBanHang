using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public string XuLyDangNhap(string email, string password)
        {
            var IsLogin = DataProvider.Ins.DB.employees.Where(x => x.email == email && x.password == password).FirstOrDefault();

            if (IsLogin == null)
            {
                return "Đăng nhập không thành công!";
            }
            return String.Format("Xin chào bạn {0} {1}", IsLogin.last_name, IsLogin.first_name);
        }

        public string XuLyDangKy(HttpPostedFileBase avatar, string last_name, string first_name, string email, string password, 
             string job_title, string department, int manager_id, string phone, 
            string address1 , string address2, string city, string state, string postal_code, string country)
        {
            string _FileName = "";
            string _ThuMucTheoThang = "";
            if (avatar.ContentLength > 0)
            {
                _FileName = Path.GetFileName(avatar.FileName);
                string _KtDuoiFile = Path.GetExtension(avatar.FileName);
                if (_KtDuoiFile == ".png"
                    || _KtDuoiFile == ".jpg" == false)
                {
                    return String.Format("File có đuôi {0) không thể tải lên", _KtDuoiFile);
                }
                DateTime now = DateTime.Now;
                _ThuMucTheoThang = String.Format("{0}{1}{2}",now.Year, now.Month, now.Day);
                string _UploadFolderPath = Server.MapPath("~/UploadedFile/" + _ThuMucTheoThang);
                if (Directory.Exists(_UploadFolderPath) == false)
                {
                    Directory.CreateDirectory(_UploadFolderPath);
                }
                
                string _path = Path.Combine(_UploadFolderPath, _FileName);
                avatar.SaveAs(_path);
            }
            try
            {
                employees ThemMoi = new employees();
                ThemMoi.last_name = last_name;
                ThemMoi.first_name = first_name;
                ThemMoi.email = email;
                ThemMoi.password = password;
                ThemMoi.avatar = _ThuMucTheoThang +"/"+ _FileName;
                ThemMoi.job_title = job_title;
                ThemMoi.department = department;
                ThemMoi.manager_id = manager_id;
                ThemMoi.phone = phone;
                ThemMoi.address1 = address1;
                ThemMoi.address2 = address2;
                ThemMoi.city = city;
                ThemMoi.state = state;
                ThemMoi.postal_code = postal_code;
                ThemMoi.country = country;

                DataProvider.Ins.DB.employees.Add(ThemMoi);
                DataProvider.Ins.DB.SaveChanges();
                return String.Format("Tài khoản {0} {1} đã được khởi tạo.", last_name, first_name);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}