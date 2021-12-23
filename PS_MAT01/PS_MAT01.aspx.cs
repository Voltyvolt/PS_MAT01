using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.OleDb;
using ExcelNumberFormat;
using DevExpress.Spreadsheet;
using System.Drawing;

namespace PS_MAT01
{
    public partial class _Default : System.Web.UI.Page
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
            Page.Response.Write("<script>console.log('" + lvSession + "');</script>");

            CellValue();
            
            FncClearLogin();
            
        }

        void CellValue()
        {
            IWorkbook workbook = ASPxSpreadsheet1.Document;
            Worksheet worksheet = workbook.Worksheets[0];

            string Quotatxt = "โควต้า";
            string Nametxt = "ชื่อ";
            string lvPlanNo = "ทะเบียนแปลง";
            string lvPlanNum = "เลขที่แปลง";
            string lvPoly = "พี้นที่";
            string lvPromise = "สัญญา(ตัน)";
            string lvAddress = "ที่ตั้ง";
            string Kethtxt = "เขต";
            string Totaltxt = "ตันประเมิน";
            string lvCarnum = "ทะเบียนรถ";
            string lvType = "ชนิดอ้อย";
            string lvName = "พนักงานจัดหาวัตถุดิบ";

            worksheet.Cells[0, 0].Value = Quotatxt;
            worksheet.Cells[0, 1].Value = Nametxt;
            worksheet.Cells[0, 2].Value = lvPlanNo;
            worksheet.Cells[0, 3].Value = lvPlanNum;
            worksheet.Cells[0, 4].Value = lvPoly;
            worksheet.Cells[0, 5].Value = lvPromise;
            worksheet.Cells[0, 6].Value = lvAddress;
            worksheet.Cells[0, 7].Value = Kethtxt;
            worksheet.Cells[0, 8].Value = Totaltxt;
            worksheet.Cells[0, 9].Value = lvCarnum;
            worksheet.Cells[0, 10].Value = lvType;
            worksheet.Cells[0, 11].Value = lvName;

            #region//จัดกึ่งกลาง Cell
            worksheet.Cells[0, 0].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 0].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 1].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 1].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 2].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 2].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 3].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 3].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 4].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 4].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 5].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 5].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 6].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 6].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 7].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 7].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 8].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 8].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 9].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 9].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            worksheet.Cells[0, 10].Alignment.Horizontal = SpreadsheetHorizontalAlignment.Center;
            worksheet.Cells[0, 11].Alignment.Vertical = SpreadsheetVerticalAlignment.Center;
            #endregion

            #region //เปลี่ยนสี Cell
            worksheet.Cells[0, 0].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 1].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 2].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 3].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 4].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 5].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 6].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 7].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 8].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 9].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 10].FillColor = Color.Aquamarine;
            worksheet.Cells[0, 11].FillColor = Color.Aquamarine;
            #endregion

            #region //ปรับความกว้าง
            worksheet.Columns[0].Width = 300;
            worksheet.Columns[1].Width = 300;
            worksheet.Columns[2].Width = 300;
            worksheet.Columns[3].Width = 300;
            worksheet.Columns[4].Width = 300;
            worksheet.Columns[5].Width = 300;
            worksheet.Columns[6].Width = 300;
            worksheet.Columns[7].Width = 300;
            worksheet.Columns[8].Width = 300;
            worksheet.Columns[9].Width = 300;
            worksheet.Columns[10].Width = 350;
            worksheet.Columns[11].Width = 450;
            #endregion
        }


        void fncExcelLoad()
        {
            try
            {
                IWorkbook workbook = ASPxSpreadsheet1.Document;
                Worksheet worksheet = workbook.Worksheets[0];
                Range usedRange = worksheet.GetUsedRange();
                //string lvUser = "";
                string lvUser = FncReadCookie("Login", "Username");
                //string lvSession = "psarea10";
                string lvSession = FncReadCookie("Login", "Username");

                string lvSQL = "";
                string lvResult = "";
                string lvNameU = txtName.Text;
              
                if (lvUser == null || lvUser == "")
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
                
                string Quota = "";
                string Name = "";
                string lvPlanNo = "";
                string lvPlanNum = "";
                string lvPoly = "";
                string lvPromise = "";
                string lvAddress = "";
                string Kethtxt = "";
                string lvTotal = "";
                string lvCarnum = "";
                string lvType = "";
                string lvName = "";
                string lvYear = "";
                string lvcanetype = "";

                int lvBreak = 0;
                for (int i = 0; i < usedRange.Count(); i++)
                {
                     Quota = worksheet.Cells[i, 0].DisplayText;
                     Name = worksheet.Cells[i, 1].DisplayText;
                     lvPlanNo = worksheet.Cells[i, 2].DisplayText;
                     lvPlanNum = worksheet.Cells[i, 3].DisplayText;
                     lvPoly = worksheet.Cells[i, 4].DisplayText;
                     lvPromise = worksheet.Cells[i, 5].DisplayText;
                     lvAddress = worksheet.Cells[i, 6].DisplayText;
                     Kethtxt = worksheet.Cells[i, 7].DisplayText;
                     lvTotal = worksheet.Cells[i, 8].DisplayText;
                     lvCarnum = worksheet.Cells[i, 9].DisplayText;
                     lvType = worksheet.Cells[i, 10].DisplayText;
                     lvName = worksheet.Cells[i, 11].DisplayText;
                     lvYear = DropDownList2.Text;
                     lvcanetype = DropDownList1.Text;

                    if (Quota != "โควต้า" && Quota != "โควตา" && Quota != "") //ตัดหัวออก
                    {
                        int lvLoop = Gstr.fncToInt(lvTotal) / 20;

                        for (int l = 0; l < lvLoop; l++)
                        {
                            string lvLoop2 = (Gstr.fncToInt(lvTotal) / 20).ToString();
                            string lvNo = (l + 1).ToString() + "/" + lvLoop2;
                            string lvNo2 = (l + 1).ToString();
                            if (lvSession == "PSAREA01")
                            {
                                lvSQL = "Insert into systemp(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea01")
                            {
                                lvSQL = "Insert into systemp(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA02")
                            {
                                lvSQL = "Insert into systemp2(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea02")
                            {
                                lvSQL = "Insert into systemp2(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA03")
                            {
                                lvSQL = "Insert into systemp3(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea03")
                            {
                                lvSQL = "Insert into systemp3(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA04")
                            {
                                lvSQL = "Insert into systemp4(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea04")
                            {
                                lvSQL = "Insert into systemp4(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA05")
                            {
                                lvSQL = "Insert into systemp5(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea05")
                            {
                                lvSQL = "Insert into systemp5(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA06")
                            {
                                lvSQL = "Insert into systemp6(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea06")
                            {
                                lvSQL = "Insert into systemp6(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA07")
                            {
                                lvSQL = "Insert into systemp7(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea07")
                            {
                                lvSQL = "Insert into systemp7(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA08")
                            {
                                lvSQL = "Insert into systemp8(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea08")
                            {
                                lvSQL = "Insert into systemp8(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA09")
                            {
                                lvSQL = "Insert into systemp9(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea09")
                            {
                                lvSQL = "Insert into systemp9(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA10")
                            {
                                lvSQL = "Insert into systemp10(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea10")
                            {
                                lvSQL = "Insert into systemp10(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA11")
                            {
                                lvSQL = "Insert into systemp11(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea11")
                            {
                                lvSQL = "Insert into systemp11(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA12")
                            {
                                lvSQL = "Insert into systemp12(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea12")
                            {
                                lvSQL = "Insert into systemp12(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA13")
                            {
                                lvSQL = "Insert into systemp13(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea13")
                            {
                                lvSQL = "Insert into systemp13(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA14")
                            {
                                lvSQL = "Insert into systemp14(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea14")
                            {
                                lvSQL = "Insert into systemp14(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA15")
                            {
                                lvSQL = "Insert into systemp15(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea15")
                            {
                                lvSQL = "Insert into systemp15(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA16")
                            {
                                lvSQL = "Insert into systemp16(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea16")
                            {
                                lvSQL = "Insert into systemp16(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA17")
                            {
                                lvSQL = "Insert into systemp17(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea17")
                            {
                                lvSQL = "Insert into systemp17(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20 ,S_Field21) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }

                            if (lvSession == "PSAREA18")
                            {
                                lvSQL = "Insert into systemp18(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else if (lvSession == "psarea18")
                            {
                                lvSQL = "Insert into systemp18(S_Field1, S_Field2, S_Field3, S_Field4, S_Field5, S_Field6, S_Field7, S_Field8, S_Field9, S_Field10, S_Field11, S_Field12, S_Field13, S_Field14, S_Field15, S_Field17 , S_Project ,S_Field20) ";
                                lvSQL += "Values ('" + Quota + "','" + Name + "','" + lvPlanNo + "','" + lvPlanNum + "','" + lvPoly + "','" + lvPromise + "','" + lvAddress + "','" + Kethtxt + "','" + lvTotal + "','" + lvType + "','" + lvName + "', '" + lvCarnum + "', '" + lvYear + "' , '" + lvNo2 + "' , '" + lvNo + "' , '" + lvNameU + "' ,'PS_MAT01', '" + lvUser + "', '" + lvcanetype + "') ";
                            }
                            else
                            {

                            }


                            
                            lvResult = GsysSQL.fncExecuteQueryData(lvSQL);
                        }
                    }

                    else
                    {
                        lvBreak += 1;
                    }
                }
            }
            catch(Exception ex)
            {
                ex.ToString();

                Page.Response.Write("<script>console.log('" + ex + "');</script>");
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            if (DropDownList1.Text == "ใบนำตัด")
            {
                fncExcelLoad();
                Response.Redirect("rptCut1View.aspx");
            }

            if (DropDownList1.Text == "ใบนำตัด Bonsucro")
            {
                fncExcelLoad();
                Response.Redirect("rptCut1View.aspx");
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