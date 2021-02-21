using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TracNghiemOnline.Modell.Dao
{
    public class LoginDao
    {
        TracNghiemOnlineDB db = new TracNghiemOnlineDB();
        internal TaiKhoan Login(TaiKhoan taiKhoan)
        {
            return db.TaiKhoans.SingleOrDefault(x => x.TaiKhoan1 == taiKhoan.TaiKhoan1 && x.MatKhau.Equals(taiKhoan.MatKhau));
        }
    }
}