<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rptCut2View.aspx.cs" Inherits="PS_MAT01.rptCut2View" %>

<%@ Register assembly="DevExpress.XtraReports.v17.1.Web, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraReports.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxDocumentViewer ID="ASPxDocumentViewer1" runat="server" Height="1100px" ReportTypeName="PS_MAT01.rpt_MAT01_Cut2" Width="100%">
            </dx:ASPxDocumentViewer>
        </div>
    </form>
</body>
</html>
