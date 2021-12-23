<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmMain.aspx.cs" Inherits="PS_MAT01.frmMain" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ประเภท"></asp:Label>
            <br />
            <br />
            <asp:DropDownList ID="DropDownList1" runat="server" Height="28px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="203px">
                <asp:ListItem>ใบนำตัด</asp:ListItem>
                <asp:ListItem>ใบนำตัด(Bonsucro)</asp:ListItem>
                <asp:ListItem>ทะเบียนรถบรรทุก</asp:ListItem>
                <asp:ListItem>โควต้า</asp:ListItem>
                <asp:ListItem>ทรัพย์สิน</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
