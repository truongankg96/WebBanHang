using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebBanHang.EF;

namespace WebBanHang.Controllers
{
    public class ApiController : Controller
    {
        
        public ActionResult GetProducts()
        {
            dynamic _ListProducts = null;
            
            _ListProducts = (from p in DataProvider.Ins.DB.products
                             select new
                             {
                                 p.id,
                                 p.product_code,
                                 p.product_name,
                                 p.standard_cost,
                                 p.list_price,
                             }).ToList();

            return Json(_ListProducts, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetKhachHang()
        {
            dynamic _ListKhachHang = null;

            _ListKhachHang = (from c in DataProvider.Ins.DB.customers
                             select new
                             {
                                c.last_name,
                                c.first_name,
                                c.email,
                                c.address1,

                             }).ToList();

            return Json(_ListKhachHang, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetNhanVien()
        {
            dynamic _ListNhanVien = null;

            _ListNhanVien = (from e in DataProvider.Ins.DB.employees
                              select new
                              {
                                  e.last_name,
                                  e.first_name,
                                  e.email,
                                  e.address1,
                                  e.phone,

                              }).ToList();

            return Json(_ListNhanVien, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDonHang()
        {
            dynamic _ListDonHang = null;

            _ListDonHang = (from o in DataProvider.Ins.DB.orders
                            join c in DataProvider.Ins.DB.customers on o.customer_id equals c.id
                            join od in DataProvider.Ins.DB.order_details on o.id equals od.order_id
                            join p in DataProvider.Ins.DB.products on od.product_id equals p.id
                             select new
                             {
                                o.id,
                                p.product_name,
                                c.last_name,
                                c.email,
                                o.order_date,
                                o.order_status,
                             }).ToList();

            return Json(_ListDonHang, JsonRequestBehavior.AllowGet);
        }

        
    }
}
