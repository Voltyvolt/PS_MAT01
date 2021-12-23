using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Parameters;

namespace PS_MAT01
{
    public partial class rptCut1View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string lvSession = FncReadCookie("Login", "UserName");
            Page.Response.Write("<script>console.log('" + lvSession + "');</script>");

            if (lvSession == "PSAREA01")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut1";
            }
            else if (lvSession == "psarea01")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut1";
            }

            else if (lvSession == "PSAREA02")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut2";
            }
            else if (lvSession == "psarea02")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut2";
            }

            else if (lvSession == "PSAREA03")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut3";
            }
            else if (lvSession == "psarea03")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut3";
            }

            else if (lvSession == "PSAREA04")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut4";
            }
            else if (lvSession == "psarea04")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut4";
            }

            else if (lvSession == "PSAREA05")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut5";
            }
            else if (lvSession == "psarea05")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut5";
            }

            else if (lvSession == "PSAREA06")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut6";
            }
            else if (lvSession == "psarea06")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut6";
            }

            else if (lvSession == "PSAREA07")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut7";
            }
            else if (lvSession == "psarea07")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut7";
            }

            else if (lvSession == "PSAREA08")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut8";
            }
            else if (lvSession == "psarea08")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut8";
            }

            else if (lvSession == "PSAREA09")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut9";
            }
            else if (lvSession == "psarea09")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut9";
            }

            else if (lvSession == "PSAREA10")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut10";
            }
            else if (lvSession == "psarea10")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut10";
            }

            else if (lvSession == "PSAREA11")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut11";
            }
            else if (lvSession == "psarea11")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut11";
            }

            else if (lvSession == "PSAREA12")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut12";
            }
            else if (lvSession == "psarea12")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut12";
            }

            else if (lvSession == "PSAREA13")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut13";
            }
            else if (lvSession == "psarea13")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut13";
            }

            else if (lvSession == "PSAREA14")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut14";
            }
            else if (lvSession == "psarea14")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut14";
            }

            else if (lvSession == "PSAREA15")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut15";
            }
            else if (lvSession == "psarea15")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut15";
            }
            else if (lvSession == "PSAREA16")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut16";
            }
            else if (lvSession == "psarea16")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut16";
            }

            else if (lvSession == "PSAREA17")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut17";
            }
            else if (lvSession == "psarea17")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut17";
            }

            else if (lvSession == "PSAREA18")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut18";
            }
            else if (lvSession == "psarea18")
            {
                ASPxWebDocumentViewer1.ReportSourceId = "PS_MAT01.rpt_MAT01_Cut18";
            }
            else
            {

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