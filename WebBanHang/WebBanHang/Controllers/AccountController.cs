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


            // Tìm trong database ông nào có email và password giống với dữ liệu người dùng gởi
            // Viết LINQ để tìm trong table `employees`, ai có `email` => username, `password` giống
            // object `context` => tương đương database
            // thuộc tính trong `context. 
            // Ví dụ: context.employees => table employees trong database
            // Ví dụ: context.products => table products trong database
            // ...

            // Viết theo style METHOD()

            // Viết theo style LINQ
            //var objEmployeeLogin2 = (from p in context.employees
            //                         where p.email == email && p.password == password
            //                         select p
            //                        ).FirstOrDefault();

            var _IsLogin = DataProvider.Ins.DB.employees.Where(x => x.email == email && x.password == password).FirstOrDefault();

            if (_IsLogin == null) // Tìm không thấy dòng hợp lệ
            {
                return "Không hợp lệ!";
            }
            else
            {
                return String.Format("Xin chào anh {0} {1}", _IsLogin.last_name, _IsLogin.first_name);
            }
        }

        [HttpPost]
        public string XuLyDangKy(HttpPostedFileBase avatar, string last_name, string first_name,
        string email, string password, string job_title, string department, int manager_id,
        string phone, string address1, string address2, string city, string state, string postal_code,
        string country)
        {
            try
            {
                string _FileName = "";
                string datetimeFolderName = "";
                // Di chuyển file vào thư mục mong muốn
                if (avatar.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(avatar.FileName);                   // QRCode_NenTangUrl.png
                    string _FileNameExtension = Path.GetExtension(avatar.FileName);  // .png
                    if ((_FileNameExtension == ".png"
                        || _FileNameExtension == ".jpg"
                        || _FileNameExtension == ".jpeg"
                        || _FileNameExtension == ".docx"
                        || _FileNameExtension == ".xls"
                        || _FileNameExtension == ".xlsx") == false)
                    {
                        return String.Format("File có đuôi {0} không được chấp nhận. Vui lòng kiểm tra lại!", _FileNameExtension);
                    }

                    DateTime now = DateTime.Now;
                    datetimeFolderName = String.Format("{0}{1}{2}{3}{4}", now.Year, now.Month, now.Day, now.Hour, now.Minute); // 201911122018
                    string uploadFolderPath = Server.MapPath("~/UploadedFiles/" + datetimeFolderName); //UploadedFiles/201911122018/ten file upload...
                    if (Directory.Exists(uploadFolderPath) == false) // Nếu thư mục cần lưu trữ file upload không tồn tại (chưa có) => Tạo mới
                    {
                        Directory.CreateDirectory(uploadFolderPath);
                    }

                    string _path = Path.Combine(uploadFolderPath, _FileName);
                    avatar.SaveAs(_path);
                }
                // Tạo 1 dòng mới `employee`

                var _TaoMoi = new employees()
                {
                    last_name = last_name,
                    first_name = first_name,
                    email = email,
                    password = password,

                    // Save tên file vào database
                    // 201911122018/QRCode_NenTangUrl.png
                    avatar = datetimeFolderName + "/" + _FileName,
                    job_title = job_title,
                    department = department,
                    manager_id = manager_id,
                    phone = phone,
                    address1 = address1,
                    address2 = address2,
                    city = city,
                    state = state,
                    postal_code = postal_code,
                    country = country,
                };
                

                // Sinh câu lệnh để lưu => kêu EntiyFramework => INSERT INTO
                DataProvider.Ins.DB.employees.Add(_TaoMoi);

                // Thực thi để lưu thực sự
                DataProvider.Ins.DB.SaveChanges();

                return String.Format("Tài khoản {0} {1} đã được khởi tạo.", last_name, first_name);
            }
            catch (Exception ex)
            {
                return String.Format("Có lỗi xảy ra, thông tin lỗi: {0}", ex.Message);
            }
        }
    }
}

