using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.EF
{
    public class DataProvider
    {
        private static DataProvider _Ins;

        public static DataProvider Ins
        {
            get
            {
                if (_Ins == null)
                {
                    _Ins = new DataProvider();
                }
                return _Ins;
            }
            set => _Ins = value;
        }

        public QuanLyBanHangEntities DB;

        public DataProvider()
        {
            DB = new QuanLyBanHangEntities();
        }
    }
}