using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace PS_MAT01
{
    public partial class rpt_MAT01_Cut5 : DevExpress.XtraReports.UI.XtraReport
    {
        string Chk = "P";
        public rpt_MAT01_Cut5()
        {
            InitializeComponent();
        }

        private void xrLabel32_TextChanged(object sender, EventArgs e)
        {
            if(xrLabel32.Text == "อ้อยสด")
            {
                lbChk1.Text = Chk;
                lbChk2.Text = "";
                lbChk3.Text = "";
            }
            else if(xrLabel32.Text == "อ้อยไฟไหม้")
            {
                lbChk1.Text = "";
                lbChk2.Text = Chk;
                lbChk3.Text = "";
            }
            else if(xrLabel32.Text == "อ้อยรถตัด")
            {
                lbChk1.Text = "";
                lbChk2.Text = "";
                lbChk3.Text = Chk;
            }
            else
            {
                lbChk1.Text = "";
                lbChk2.Text = "";
                lbChk3.Text = "";
            }
        }

        private void rpt_MAT01_Cut1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {


        }

        private void xrLabel32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void xrLabel32_AfterPrint(object sender, EventArgs e)
        {
           
        }

        private void xrLabel37_TextChanged(object sender, EventArgs e)
        {
            if(xrLabel37.Text == "ใบนำตัด")
            {
                xrPictureBox2.Visible = true;
                xrPictureBox1.Visible = false;
            }
            else
            {
                xrPictureBox2.Visible = false;
                xrPictureBox1.Visible = true;
            }
        }

        private void rpt_MAT01_Cut1_AfterPrint(object sender, EventArgs e)
        {
            
        }
    }
}
