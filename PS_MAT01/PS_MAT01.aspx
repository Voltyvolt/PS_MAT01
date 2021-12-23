<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="PS_MAT01.aspx.cs" Inherits="PS_MAT01._Default" %>

<%@ Register assembly="DevExpress.Web.ASPxSpreadsheet.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpreadsheet" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.Bootstrap" tagprefix="dx" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">

    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/popper.min.js"></script>

    <p>
        <br />
    </p>
    <div>
        <center>
            <img src="images/Excel-icon.png" alt="" height="25px" width="25px"/>
            <asp:Label ID="Label1" runat="server" Text="วางข้อมูลจาก Excel" Font-Bold="True" Font-Size="Large"></asp:Label>
        </center>
        <br />
        <center>
            <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" Width="200px" HeaderText="โปรแกรม ใบนำตัดอ้อย" Theme="iOS">
                <PanelCollection>
                    <dx:PanelContent runat="server">
                        <div style="text-align: left">
                            <div style="text-align: left">
                                <dx:ASPxRoundPanel ID="ASPxRoundPanel2" runat="server" HeaderText="วิธีใช้" Theme="iOS" View="GroupBox" Width="200px">
                                    <PanelCollection>
                                        <dx:PanelContent runat="server">
                                            <div style="width: 242px">
                                            1. เลือกประเภทใบนำตัด<br/>
                                            2. Copy ข้อมูลจาก Excel ลงในตาราง<br/>
                                            3. กดปุ่ม Enter หรือ Click ที่ Cell อื่นในตารางทุกครั้งที่กรอกข้อมูลสำเร็จ<br/>
                                            4. กดปุ่ม Upload<br/>
                                            </div>
                                        </dx:PanelContent>
                                    </PanelCollection>
                                </dx:ASPxRoundPanel>
                                <br />
                            </div>
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="เลือกประเภท : ">
                            </dx:ASPxLabel>
                            &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>ใบนำตัด</asp:ListItem>
                                <asp:ListItem>ใบนำตัด Bonsucro</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;
                            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="เลือกปีการผลิต : ">
                            </dx:ASPxLabel>
                            &nbsp;<asp:DropDownList ID="DropDownList2" runat="server" Height="18px" Width="137px">
                                <asp:ListItem>2564/2565</asp:ListItem>
                                <asp:ListItem>2563/2564</asp:ListItem>
                                <asp:ListItem>2563/2564</asp:ListItem>
                                <asp:ListItem>2562/2563</asp:ListItem>
                                <asp:ListItem>2561/2562</asp:ListItem>
                                <asp:ListItem></asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;
                            <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="รหัสผู้พิมพ์บัตร : ">
                            </dx:ASPxLabel>
                            &nbsp;<asp:TextBox ID="txtName" runat="server" Width="165px"></asp:TextBox>
                            <br />
                            <br />
                            <dx:ASPxSpreadsheet ID="ASPxSpreadsheet1" runat="server" WorkDirectory = "~/App_Data/WorkDirectory" RibbonMode="None" ShowFormulaBar="False" ShowSheetTabs="False" Theme="Office2010Blue">
                            </dx:ASPxSpreadsheet>
                    </dx:PanelContent>
                </PanelCollection>
            </dx:ASPxRoundPanel>
        </center>
        <br>
        <center>
            <dx:ASPxButton ID="ASPxButton1" runat="server" Text="Upload" OnClick="ASPxButton1_Click" Theme="Moderno">
                <Image IconID="actions_download_16x16">
                </Image>
            </dx:ASPxButton>
        </center>
        <br />
        <br />
        <div>
            <center>
                <br />
            </center>
        </div>
    </div>

      

</asp:Content>