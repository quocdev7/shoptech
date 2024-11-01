using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopdodadung
{
    public static class Thongbao
    {
        public static bool has_flash()
        {
            if(HttpContext.Current.Session["Thongbao"].Equals(""))
            {
                return false;
            }
            return true;
        }
        public static void set_flash(String msg, String msg_type)
        {
            ThongbaoModel thongbao = new ThongbaoModel();
            thongbao.msg = msg;
            thongbao.msg_type = msg_type;
            System.Web.HttpContext.Current.Session["Thongbao"] = thongbao;
        }
        public static ThongbaoModel get_flash()
        {
            ThongbaoModel thongbao = (ThongbaoModel)System.Web.HttpContext.Current.Session["Thongbao"];
            System.Web.HttpContext.Current.Session["Thongbao"] = "";
            return thongbao;
        }
    }
}