using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace PS_MAT01
{
    public partial class rpt_MAT01_CutB : DevExpress.XtraReports.UI.XtraReport
    {
        public rpt_MAT01_CutB()
        {
            InitializeComponent();
        }

        private void xrLabel32_TextChanged(object sender, EventArgs e)
        {
            if (xrLabel32.Text == "อ้อยสด")
            {
                lbChk1.Text = "P";
                lbChk2.Text = "";
                lbChk3.Text = "";
            }
            else if (xrLabel32.Text == "อ้อยไฟไหม้")
            {
                lbChk1.Text = "";
                lbChk2.Text = "P";
                lbChk3.Text = "";
            }
            else if (xrLabel32.Text == "อ้อยรถตัด")
            {
                lbChk1.Text = "";
                lbChk2.Text = "";
                lbChk3.Text = "P";
            }
            else
            {
                lbChk1.Text = "";
                lbChk2.Text = "";
                lbChk3.Text = "";
            }
        }

        private void rpt_MAT01_Cut2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            string lvUser = "";

            if (GVar.gvUser1 == "psarea01")
            {
                lvUser = GVar.gvUser1;
            }
            else if (GVar.gvUser2 == "psarea02")
            {
                lvUser = GVar.gvUser2;
            }
            else if (GVar.gvUser3 == "psarea03")
            {
                lvUser = GVar.gvUser3;
            }
            else if (GVar.gvUser4 == "psarea04")
            {
                lvUser = GVar.gvUser4;
            }
            else if (GVar.gvUser5 == "psarea05")
            {
                lvUser = GVar.gvUser5;
            }
            else if (GVar.gvUser6 == "psarea06")
            {
                lvUser = GVar.gvUser6;
            }
            else if (GVar.gvUser7 == "psarea07")
            {
                lvUser = GVar.gvUser7;
            }
            else if (GVar.gvUser8 == "psarea08")
            {
                lvUser = GVar.gvUser8;
            }
            else if (GVar.gvUser9 == "psarea09")
            {
                lvUser = GVar.gvUser9;
            }
            else if (GVar.gvUser10 == "psarea10")
            {
                lvUser = GVar.gvUser10;
            }
            else if (GVar.gvUser11 == "psarea11")
            {
                lvUser = GVar.gvUser11;
            }
            else if (GVar.gvUser12 == "psarea12")
            {
                lvUser = GVar.gvUser12;
            }
            else if (GVar.gvUser13 == "psarea13")
            {
                lvUser = GVar.gvUser13;
            }
            else if (GVar.gvUser14 == "psarea14")
            {
                lvUser = GVar.gvUser14;
            }
            else if  (GVar.gvUser15 == "psarea15")
            {
                lvUser = GVar.gvUser15;
            }
            else if (GVar.gvUser16 == "psarea16")
            {
                lvUser = GVar.gvUser16;
            }
            else if (GVar.gvUser17 == "psarea17")
            {
                lvUser = GVar.gvUser17;
            }
            else if (GVar.gvUser18 == "psarea18")
            {
                lvUser = GVar.gvUser18;
            }

            xrLabel37.Text = lvUser;

           
        }

        private void xrLabel32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void xrLabel32_AfterPrint(object sender, EventArgs e)
        {
           
        }

        private void rpt_MAT01_Cut2_AfterPrint(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            string lvSQL = "Select * From systemp WHERE S_Project = 'PS_MAT01' AND S_Field20 = '" + xrLabel37.Text + "' ";
            DT = GsysSQL.fncGetQueryData(lvSQL, DT);

            for (int i = 0; i < DT.Rows.Count; i++)
            {
                xrLabel5.Text = DT.Rows[i]["S_Field15"].ToString();
                xrLabel11.Text = DT.Rows[i]["S_Field14"].ToString();
                xrLabel7.Text = DT.Rows[i]["S_Field1"].ToString();
                xrLabel13.Text = DT.Rows[i]["S_Field3"].ToString();
                xrLabel15.Text = DT.Rows[i]["S_Field4"].ToString();
                xrLabel17.Text = DT.Rows[i]["S_Field5"].ToString();
                xrLabel20.Text = DT.Rows[i]["S_Field6"].ToString();
                xrLabel23.Text = DT.Rows[i]["S_Field7"].ToString();
                xrLabel25.Text = DT.Rows[i]["S_Field9"].ToString();
                xrLabel28.Text = DT.Rows[i]["S_Field8"].ToString();
                xrLabel30.Text = DT.Rows[i]["S_Field12"].ToString();
                xrLabel39.Text = DT.Rows[i]["S_Field11"].ToString();
                xrLabel32.Text = DT.Rows[i]["S_Field10"].ToString();
            }
        }
    }
}
