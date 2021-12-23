using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PS_MAT01
{
    public partial class rptCut2View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string lvSession = FncReadCookie("Login", "Username");
            //string lvSession = "psarea04";
            Page.Response.Write("<script>console.log('" + lvSession + "');</script>");

            if (lvSession == "PSAREA01")
            {
                GVar.gvUser1 = lvSession;
            }
            else if (lvSession == "psarea01")
            {
                GVar.gvUser1 = lvSession;
            }

            else if (lvSession == "PSAREA02")
            {
                GVar.gvUser2 = lvSession;
            }
            else if (lvSession == "psarea02")
            {
                GVar.gvUser2 = lvSession;
            }

            else if (lvSession == "PSAREA03")
            {
                GVar.gvUser3 = lvSession;
            }
            else if (lvSession == "psarea03")
            {
                GVar.gvUser3 = lvSession;
            }

            else if (lvSession == "PSAREA04")
            {
                GVar.gvUser4 = lvSession;
            }
            else if (lvSession == "psarea04")
            {
                GVar.gvUser4 = lvSession;
            }

            else if (lvSession == "PSAREA05")
            {
                GVar.gvUser5 = lvSession;
            }
            else if (lvSession == "psarea05")
            {
                GVar.gvUser5 = lvSession;
            }

            else if (lvSession == "PSAREA06")
            {
                GVar.gvUser6 = lvSession;
            }
            else if (lvSession == "psarea06")
            {
                GVar.gvUser6 = lvSession;
            }

            else if (lvSession == "PSAREA07")
            {
                GVar.gvUser7 = lvSession;
            }
            else if (lvSession == "psarea07")
            {
                GVar.gvUser7 = lvSession;
            }

            else if (lvSession == "PSAREA08")
            {
                GVar.gvUser8 = lvSession;
            }
            else if (lvSession == "psarea08")
            {
                GVar.gvUser8 = lvSession;
            }

            else if (lvSession == "PSAREA09")
            {
                GVar.gvUser9 = lvSession;
            }
            else if (lvSession == "psarea09")
            {
                GVar.gvUser9 = lvSession;
            }

            else if (lvSession == "PSAREA10")
            {
                GVar.gvUser10 = lvSession;
            }
            else if (lvSession == "psarea10")
            {
                GVar.gvUser10 = lvSession;
            }

            else if (lvSession == "PSAREA11")
            {
                GVar.gvUser11 = lvSession;
            }
            else if (lvSession == "psarea11")
            {
                GVar.gvUser11 = lvSession;
            }

            else if (lvSession == "PSAREA12")
            {
                GVar.gvUser12 = lvSession;
            }
            else if (lvSession == "psarea12")
            {
                GVar.gvUser12 = lvSession;
            }

            else if (lvSession == "PSAREA13")
            {
                GVar.gvUser13 = lvSession;
            }
            else if (lvSession == "psarea13")
            {
                GVar.gvUser13 = lvSession;
            }

            else if (lvSession == "PSAREA14")
            {
                GVar.gvUser14 = lvSession;
            }
            else if (lvSession == "psarea14")
            {
                GVar.gvUser14 = lvSession;
            }

            else if (lvSession == "PSAREA15")
            {
                GVar.gvUser15 = lvSession;
            }
            else if (lvSession == "psarea15")
            {
                GVar.gvUser15 = lvSession;
            }

            else if (lvSession == "PSAREA16")
            {
                GVar.gvUser16 = lvSession;
            }
            else if (lvSession == "psarea16")
            {
                GVar.gvUser16 = lvSession;
            }

            else if (lvSession == "PSAREA17")
            {
                GVar.gvUser17 = lvSession;
            }
            else if (lvSession == "psarea17")
            {
                GVar.gvUser17 = lvSession;
            }

            else if (lvSession == "PSAREA18")
            {
                GVar.gvUser18 = lvSession;
            }
            else if (lvSession == "psarea18")
            {
                GVar.gvUser18 = lvSession;
            }
        }

        private void FncCheckLoginWeb()
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            string lvCookieUser = "";
            string lvOnline = "";

            //ถ้าขึ้นต้นด้วยไอพี ไม่ต้อง Login
            if (url.Contains("10.104.1.9"))
            {
                //ไม่ต้อง Login
            }
            else
            {
                //ดึงข้อมูล User เพื่อนำมาเช็คสถานะออนไลน์
                lvCookieUser = FncReadCookie("Login", "Username");

                //ถ้า Login ออนไลน์ไว้อยู่แล้วก็แสดงข้อมูลต่อได้เลย ถ้าไม่ ให้ Login ใหม่
                lvOnline = GsysSQL.fncCheckOnlineStatus(lvCookieUser);

                if (lvOnline != "")
                {
                    string lvDateNow = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
                    string lvTimeNow = DateTime.Now.ToString("HHmmss");

                    //ถ้าออนไลน์ให้บันทึก LastUpdate ไปใหม่
                    string lvSQL = "Update SysLoginTable set L_Update = '" + lvDateNow + lvTimeNow + "' Where L_UserName = '" + lvCookieUser + "' ";
                    string lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
                }
                else
                {
                    //MessageboxAlert("ไม่พบข้อมูลผู้ใช้ของท่าน กรุณาเข้าสู่ระบบใหม่อีกครั้ง");

                    //สร้าง Cookie ส่งข้อมูล Url
                    FncCreateCookie("Url", "LastUrl", url);

                    //ถ้าไม่ออนไลน์ให้ Login ใหม่
                    string lvUrlNew = "/LoginMonitor.aspx";// + "?LastUrl=" + url
                    Response.Redirect(lvUrlNew);
                }
            }
        }

        private void FncClearLogin()
        {
            string lvSQL = "";
            string lvResault = "";
            string lvDateNow = Gstr.fncChangeTDate(DateTime.Now.ToString("dd/MM/yyyy"));
            string lvTimeNow = DateTime.Now.ToString("HHmmss");
            string lvDateDiff = Gstr.fncChangeTDate(DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy"));

            lvSQL = "Delete From SysLoginTable Where L_Update < '" + lvDateDiff + lvTimeNow + "' ";
            lvResault = GsysSQL.fncExecuteQueryData(lvSQL);
        }

        private string FncReadCookie(string lvKeys, string lvName)
        {
            string lvReturn = "Success";

            try
            {
                lvReturn = Request.Cookies[lvKeys][lvName];
            }
            catch (Exception ex)
            {
                lvReturn = ex.Message;
            }

            return lvReturn;
        }

        private void FncCreateCookie(string lvKeyName, string lvName, string lvData)
        {
            //*** Instance of the HttpCookies ***//
            HttpCookie newCookie = new HttpCookie(lvKeyName);
            newCookie[lvName] = lvData;
            newCookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Add(newCookie);
        }

        private void FncDeleteCookie(string lvKeyName)
        {
            HttpCookie delCookie1;
            delCookie1 = new HttpCookie(lvKeyName);
            delCookie1.Expires = DateTime.Now.AddDays(-1D);
            Response.Cookies.Add(delCookie1);
        }
    }
}