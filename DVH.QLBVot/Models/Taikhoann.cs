using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVH.QLBVot.Models
{
    public class Taikhoann
    {
        public TaiKhoan ChiTiet(string tenDangNhap)
        {
            try
            {
                QUANLYBANVOTEntities db = new QUANLYBANVOTEntities();
                var model = db.TaiKhoans.SingleOrDefault(m=>m.TenDangNhap == tenDangNhap.ToLower());
                return model;
            }
            catch
            {
                return null;
            }

        }
    }

}