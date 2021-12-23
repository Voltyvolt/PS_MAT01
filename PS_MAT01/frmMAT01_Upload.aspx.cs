using DevExpress.Spreadsheet;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Parameters;
using System.Data.SqlClient;

namespace PS_MAT01
{
    public partial class frmMAT01_Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string lvSession = "";
            if (!IsPostBack)
            {
                bool lvTablet = false;

                //ถ้า Error Default User Admin ไป
                try
                {
                    GVar.gvUser = Session["UserName"].ToString();
                    Session["X"] = Session["UserName"].ToString();
                    lvSession = FncReadCookie("Login", "Username");
                    FncCheckLoginWeb();
                    //GVar.gvUser = "admin";
                }
                catch (Exception ex)
                {
                    //GVar.gvUser = "PSAREA14";
                    //GVar.gvUser = "ADMIN";
                    //Session["X"] = "admin";
                }
            }

            //string lvCookieUser = FncReadCookie("Login", "Username");
            Page.Response.Write("<script>console.log('" + lvSession + "');</script>");
            FncClearLogin();
            
            Page.MaintainScrollPositionOnPostBack = true; //PagePostback ไม่ต้องขึ้นมาด้านบน
            //fncLoadData();
        }

        private void fncDownloadFile(string lvFileName)
        {
            //Response.ContentType = "application/octect-stream";
            //Response.AppendHeader("content-disposition", "filename=" + lvFileName + "");
            //Response.TransmitFile(Server.MapPath("~/File/MAT01/" + lvFileName + ""));
            //Response.End();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {

        }

        protected void btnExcelUp_Click(object sender, EventArgs e)
        {

        }

        private void LoadDataFromExcel()
        {

        }

        protected void btnAccept_Click(object sender, EventArgs e)
        {
            //if(cmbType.Text == "ใบนำตัด")
            //{
            //    fncAcceptData();
            //    Response.Redirect("rptCut1View.aspx");
            //}
            //if(cmbType.Text == "ใบนำตัด Bonsurco")
            //{
            //    fncAcceptData();
            //    Response.Redirect("rptCut2View.aspx");
            //}
        }

        private void fncLoadData()
        {
            var Quota = txtQuota.Text;
            var SeasonYear = "64";
            DataTable DT = new DataTable();
            var lvSQL = "Select Plans.Code AS CodeId, Plans.Name AS Name from ContractPlans inner join Plans ON ContractPlans.PlanId = Plans.Id INNER JOIN " +
                "PlanGps On Plans.Id = PlanGps.PlanId INNER JOIN CaneSeasons ON Plans.CaneSeasonId = CaneSeasons.Id INNER JOIN Quotas ON Plans.QuotaId = Quotas.Id " +
                "Where Quotas.Code = '" + Quota + "' And Plans.Status = '2' And SeasonYear = '" + SeasonYear + "'";
            DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);

            DataTable newDT = new DataTable();
            newDT.Columns.Add("Id");
            newDT.Columns.Add("Code");
            newDT.Columns.Add("PlName");

            GridView1.DataSource = null;

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                int id = i + 1;
                var Code = DT.Rows[i]["CodeId"].ToString();
                var PlName = DT.Rows[i]["Name"].ToString();

                newDT.Rows.Add(new object[] { id, Code, PlName });

                
                GridView1.DataSource = newDT;
                GridView1.DataBind();
            }
        }

        private void fncAcceptData()
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
            //FileUpload1.SaveAs(Server.MapPath("~/File/MAT01U/") + Path.GetFileName(FileUpload1.FileName));
            var lvSQL = "";
            var lvResult = "";

            int lvBreak = 0;
            //ถ้าไม่มีให้ Default เป็น 1
            //string lvUser = "psarea10";
            string lvUser = FncReadCookie("Login", "Username");
            //string lvSession = "psarea10";
            string lvSession = FncReadCookie("Login", "Username");

            if (lvSession == null || lvSession == "")
            {
                Response.Redirect("~/Account/Login.aspx");
            }

            if (lvSession == "PSAREA01")
            {
                lvSQL = "Delete From systemp";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea01")
            {
                lvSQL = "Delete From systemp";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA02")
            {
                lvSQL = "Delete From systemp2";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea02")
            {
                lvSQL = "Delete From systemp2";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA03")
            {
                lvSQL = "Delete From systemp3";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea03")
            {
                lvSQL = "Delete From systemp3";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA04")
            {
                lvSQL = "Delete From systemp4";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea04")
            {
                lvSQL = "Delete From systemp4";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA05")
            {
                lvSQL = "Delete From systemp5";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea05")
            {
                lvSQL = "Delete From systemp5";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA06")
            {
                lvSQL = "Delete From systemp6";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea06")
            {
                lvSQL = "Delete From systemp6";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA07")
            {
                lvSQL = "Delete From systemp7";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea07")
            {
                lvSQL = "Delete From systemp7";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA08")
            {
                lvSQL = "Delete From systemp8";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea08")
            {
                lvSQL = "Delete From systemp8";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA09")
            {
                lvSQL = "Delete From systemp9";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea09")
            {
                lvSQL = "Delete From systemp9";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA10")
            {
                lvSQL = "Delete From systemp10";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea10")
            {
                lvSQL = "Delete From systemp10";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA11")
            {
                lvSQL = "Delete From systemp11";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea11")
            {
                lvSQL = "Delete From systemp11";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA12")
            {
                lvSQL = "Delete From systemp12";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea12")
            {
                lvSQL = "Delete From systemp12";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA12")
            {
                lvSQL = "Delete From systemp12";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea12")
            {
                lvSQL = "Delete From systemp12";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA13")
            {
                lvSQL = "Delete From systemp13";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea13")
            {
                lvSQL = "Delete From systemp13";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA14")
            {
                lvSQL = "Delete From systemp14";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea14")
            {
                lvSQL = "Delete From systemp14";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA15")
            {
                lvSQL = "Delete From systemp15";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea15")
            {
                lvSQL = "Delete From systemp15";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA16")
            {
                lvSQL = "Delete From systemp16";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea16")
            {
                lvSQL = "Delete From systemp16";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA17")
            {
                lvSQL = "Delete From systemp17";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea17")
            {
                lvSQL = "Delete From systemp17";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            if (lvSession == "PSAREA18")
            {
                lvSQL = "Delete From systemp18";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }
            else if (lvSession == "psarea18")
            {
                lvSQL = "Delete From systemp18";
                lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            }

            Page.Response.Write("<script>console.log('" + lvSession + "');</script>");


            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                var Quota = txtQuota.Text;
                var Name = txtFullName.Text;
                var SeasonYears = "64";
                var lvPlanNo = "";
                var Type = cmbType.Text;
                var lvPlanNum = GridView1.Rows[i].Cells[1].Text;
                var CaneTypeUse = ((DropDownList) GridView1.Rows[i].FindControl("cmbCanetype")).SelectedValue.Trim();

                if(CaneTypeUse != "")
                {
                    DataTable DT = new DataTable();
                    lvSQL = "Select DISTINCT Plans.Code,Plans.Name as Plname,GisRai,ForecastTonPerRai,CaneSeasons.Name, Plans.CaneSeasonId as CSname,Plans.SeasonYear, RegAddressNo, RegMoo, RegTambonName, RegAmphurName, RegProvinceName, RegAddressZipcode " +
                            "from ContractPlans " +
                            "INNER JOIN Plans ON ContractPlans.PlanId = Plans.Id " +
                            "INNER JOIN PlanGps On Plans.Id = PlanGps.PlanId " +
                            "INNER JOIN CaneSeasons ON Plans.CaneSeasonId = CaneSeasons.Id " +
                            "INNER JOIN Quotas ON Plans.QuotaId = Quotas.Id " +
                            "Where Quotas.Code = '" + Quota + "' And Plans.SeasonYear = '" + SeasonYears + "' And Plans.Code = '" + lvPlanNum + "' GROUP BY Plans.Code,Plans.Name,GisRai,ForecastTonPerRai,CaneSeasons.Name,Plans.SeasonYear,Plans.CaneSeasonId, RegAddressNo, RegMoo, RegTambonName, RegAmphurName, RegProvinceName, RegAddressZipcode";
                    DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);

                    for (int k = 0; k < DT.Rows.Count; k++)
                    {
                        var lvPoly = DT.Rows[k]["GisRai"].ToString();
                        var lvForecastTonPerRai = DT.Rows[k]["ForecastTonPerRai"].ToString();
                        var lvPromise = Gstr.fncToInt(lvPoly) * Gstr.fncToInt(lvForecastTonPerRai);
                        var RegAddressNo = DT.Rows[k]["RegAddressNo"].ToString();
                        var RegMoo = DT.Rows[k]["RegMoo"].ToString();
                        var RegTambonName = DT.Rows[k]["RegTambonName"].ToString();
                        var RegAmphurName = DT.Rows[k]["RegAmphurName"].ToString();
                        var RegProvinceName = DT.Rows[k]["RegProvinceName"].ToString();
                        var RegAddressZipCode = DT.Rows[k]["RegAddressZipCode"].ToString();
                        var lvAddress = RegAddressNo + " " + RegMoo + " " + RegTambonName + " " + RegAmphurName + " " + RegProvinceName + " " + RegProvinceName + " " + RegAddressZipCode;
                        var Kethtxt = cmbKeth.Text;
                        var lvTotal = lvPromise;
                        var lvCarnum = "";
                        var lvType2 = CaneTypeUse;
                        var lvName3 = "";
                        var lvNameU = "";

                        var lvYear = cmbYear.Text;
                        var lvBarCode = Quota + "P" + lvPlanNum;

                        var lvLoop = lvTotal / 20;

                        for (int l = 0; l < lvLoop; l++)
                        {
                            var lvLoop2 = (lvTotal / 20).ToString();
                            var lvNo = (l + 1).ToString() + "/" + lvLoop2;
                            var lvNo2 = (l + 1).ToString();

                            //string lvSession = FncReadCookie("Login", "Username");
                            
                            if (lvSession == "PSAREA01")
                            {
                                lvSQL = "Insert into systemp(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea01")
                            {
                                lvSQL = "Insert into systemp(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                            if (lvSession == "PSAREA02")
                            {
                                lvSQL = "Insert into systemp2(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea02")
                            {
                                lvSQL = "Insert into systemp2(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA03")
                            {
                                lvSQL = "Insert into systemp3(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea03")
                            {
                                lvSQL = "Insert into systemp3(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA04")
                            {
                                lvSQL = "Insert into systemp4(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea04")
                            {
                                lvSQL = "Insert into systemp4(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA05")
                            {
                                lvSQL = "Insert into systemp5(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea05")
                            {
                                lvSQL = "Insert into systemp5(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA06")
                            {
                                lvSQL = "Insert into systemp6(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea06")
                            {
                                lvSQL = "Insert into systemp6(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA07")
                            {
                                lvSQL = "Insert into systemp7(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea07")
                            {
                                lvSQL = "Insert into systemp7(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA08")
                            {
                                lvSQL = "Insert into systemp8(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea08")
                            {
                                lvSQL = "Insert into systemp8(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA09")
                            {
                                lvSQL = "Insert into systemp9(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea09")
                            {
                                lvSQL = "Insert into systemp9(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA10")
                            {
                                lvSQL = "Insert into systemp10(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea10")
                            {
                                lvSQL = "Insert into systemp10(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA11")
                            {
                                lvSQL = "Insert into systemp11(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea11")
                            {
                                lvSQL = "Insert into systemp11(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA12")
                            {
                                lvSQL = "Insert into systemp12(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea12")
                            {
                                lvSQL = "Insert into systemp12(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA13")
                            {
                                lvSQL = "Insert into systemp13(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea13")
                            {
                                lvSQL = "Insert into systemp13(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA14")
                            {
                                lvSQL = "Insert into systemp14(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea14")
                            {
                                lvSQL = "Insert into systemp14(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA15")
                            {
                                lvSQL = "Insert into systemp15(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea15")
                            {
                                lvSQL = "Insert into systemp15(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA16")
                            {
                                lvSQL = "Insert into systemp16(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea16")
                            {
                                lvSQL = "Insert into systemp16(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA17")
                            {
                                lvSQL = "Insert into systemp17(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea17")
                            {
                                lvSQL = "Insert into systemp17(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }

                             if (lvSession == "PSAREA18")
                            {
                                lvSQL = "Insert into systemp18(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field211) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else if (lvSession == "psarea18")
                            {
                                lvSQL = "Insert into systemp18(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project, S_Field20, S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarCode + "' ,'PS_MAT01', '" + lvUser + "', '" + Type + "') ";
                            }
                            else
                            {

                            }
                            

                            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                        }
                    }
                }
            }


            //int lvBreak = 0;
            //for (int i = 0; i < usedRange.Count(); i++)
            //{
            //    string Quota = txtQuota.Text;
            //    string Name = txtFullName.Text;
            //    string lvPlanNum = cmbPlanCode.Text;
            //    string lvPlanNo = worksheet.Cells[i, 0].DisplayText;
            //    string lvPoly = worksheet.Cells[i, 1].DisplayText;
            //    string lvPromise = worksheet.Cells[i, 2].DisplayText;
            //    string lvAddress = worksheet.Cells[i, 3].DisplayText;
            //    string Kethtxt = worksheet.Cells[i, 4].DisplayText;
            //    string lvTotal = worksheet.Cells[i, 5].DisplayText;
            //    string lvCarnum = worksheet.Cells[i, 6].DisplayText;
            //    string lvType2 = worksheet.Cells[i, 7].DisplayText;
            //    string lvName3 = worksheet.Cells[i, 8].DisplayText;
            //    string lvYear = cmbYear.Text;
            //    string lvBarcode = Quota + "P" + lvPlanNum;

            //    if (lvPlanNo != "ทะเบียนแปลง") //ตัดหัวออก
            //    {
            //        int lvLoop = Gstr.fncToInt(lvTotal) / 20;

            //        for (int l = 0; l < lvLoop; l++)
            //        {
            //            string lvLoop2 = (Gstr.fncToInt(lvTotal) / 20).ToString();
            //            string lvNo = (l + 1).ToString() + "/" + lvLoop2;
            //            string lvNo2 = (l + 1).ToString();
            //            lvSQL = "Insert into systemp(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field16 , S_Field17 , S_Field18, S_Field19, S_Project) ";
            //            lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType2 + "','" + lvName3 + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvUser + "', '" + lvNameU + "', '" + lvNameU + "', '" + lvBarcode + "' ,'PS_MAT01') ";
            //            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
            //        }
            //    }

            //    else
            //    {
            //        lvBreak += 1;
            //    }
            //}
        }

        private void fncGetPlanID(string lvQuota, string lvSeasonYears) {
            //DataTable DT = new DataTable();
            //var lvSQL = "Select Code AS CodeId, Plans.Name AS Name from ContractPlans inner join Plans ON ContractPlans.PlanId = Plans.Id INNER JOIN PlanGps On Plans.Id = PlanGps.PlanId INNER JOIN CaneSeasons ON Plans.CaneSeasonId = CaneSeasons.Id Where QuotaId = '" + lvQuota + "' And Status = '2' And SeasonYear = '" + lvSeasonYears + "'";
            //DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);
            //cmbPlanCode.Items.Add("ทั้งหมด");
            //for (int i = 0; i < DT.Rows.Count; i++)
            //{
            //    var Data = DT.Rows[i]["CodeId"].ToString();

            //    cmbPlanCode.Items.Add(Data);
            //}

        }

        private void fncGetName(string lvQuota)
        {
            DataTable DT = new DataTable();
            var lvSQL = "Select FirstNameTH, LastNameTH From Quotas Where Code = '" + lvQuota + "'";
            DT = GsysSQL.fncGetQueryDataMCSS(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                var FirstName = DT.Rows[i]["FirstNameTH"].ToString();
                var LastName = DT.Rows[i]["LastNameTH"].ToString();
                string FullName = FirstName + " " + LastName;

                txtFullName.Text = FullName;
                
            }
        }

        private string fncGetSeasonYears()
        {
            var lvReturn = "";

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["PSConnection"].ToString());
                MySqlCommand cmd = new MySqlCommand();
                MySqlDataReader dr;

                var lvSQL = "Select Year - 1 AS Year From seasonyears Order By Id DESC Limit 1";

                cmd.Connection = con;
                con.Open();
                cmd.CommandText = lvSQL;
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lvReturn = dr["Year"].ToString();
                        //GVar.gvFirstUrl = dr["us_URL"].ToString();
                        //GVar.gvKet = dr["us_Ket"].ToString();
                        //GVar.gvUserType = dr["us_Type"].ToString();
                    }
                }
                dr.Close();
                con.Close();

                return lvReturn;
            }
            catch (Exception ex)
            {
                var e = ex.Message;
                return e;
            }
        }

        protected void txtQuota_TextChanged(object sender, EventArgs e)
        {
            string Quota = txtQuota.Text;
            string SeasonYear = fncGetSeasonYears();
            fncGetName(Quota);
            fncLoadData();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAccept_Click1(object sender, EventArgs e)
        {
            if (cmbType.Text == "ใบนำตัด")
            {
                fncAcceptData();
                Response.Redirect("rptCut1View.aspx");
            }
            if (cmbType.Text == "ใบนำตัด Bonsurco")
            {
                fncAcceptData();
                Response.Redirect("rptCut1View.aspx");
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            fncLoadData();
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
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
                    string lvUrlNew = "~/Account/Login.aspx";// + "?LastUrl=" + url
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
            Page.Response.Write("<script>console.log('" + lvReturn + "');</script>");

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