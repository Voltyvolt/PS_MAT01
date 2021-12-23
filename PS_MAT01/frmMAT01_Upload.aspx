<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="frmMAT01_Upload.aspx.cs" Inherits="PS_MAT01.frmMAT01_Upload" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpreadsheet.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxSpreadsheet" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css2?family=Prompt:wght@500&display=swap" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <style>


        table.mygridview {
            font-family: 'Prompt', sans-serif;
            text-align: center;
            border-collapse: collapse;
            font-size: 16px;
            width: 100%;
        }

            table.mygridview td, table.mygridview th {
                border: 1px solid #ddd;
                padding: 8px;
            }

            table.mygridview tr:nth-child(even) {
                background-color: #f2f2f2;
            }

            table.mygridview tr:hover {
                background-color: #ddd;
            }

            table.mygridview th {
                padding-top: 12px;
                padding-bottom: 12px;
                text-align: center;
                background-color: #4CAF50;
                text-shadow: 2px 2px black;
                color: white;
            }
    </style>
    <p>
        <br />
        <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowCollapseButton="true" ShowHeader="False" Width="100%" Font-Size="18pt">
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <center>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Font-Size="XX-Large" Text="โปรแกรมพิมพ์ใบนำตัด">
                        </dx:ASPxLabel>
                    </center>
                    <br />
                    <center>
                        <dx:ASPxFormLayout ID="ASPxFormLayout1" runat="server">
                            <Items>
                                <dx:LayoutGroup Caption="" ColCount="12">
                                    <Items>
                                        <dx:LayoutItem Caption="ประเภทใบนำตัด" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="cmbType" runat="server">
                                                        <Items>
                                                            <dx:ListEditItem Text="ใบนำตัด" Value="0" />
                                                            <dx:ListEditItem Text="ใบนำตัด Bonsurco" Value="1" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="โควต้า" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtQuota" runat="server" AutoPostBack="True" OnTextChanged="txtQuota_TextChanged">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="ชื่อ" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtFullName" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="เขต" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="cmbKeth" runat="server">
                                                        <Items>
                                                            <dx:ListEditItem Text="1" Value="0" />
                                                            <dx:ListEditItem Text="1/1" Value="18" />
                                                            <dx:ListEditItem Text="2" Value="1" />
                                                            <dx:ListEditItem Text="3" Value="2" />
                                                            <dx:ListEditItem Text="4" Value="3" />
                                                            <dx:ListEditItem Text="5" Value="4" />
                                                            <dx:ListEditItem Text="6" Value="5" />
                                                            <dx:ListEditItem Text="7" Value="6" />
                                                            <dx:ListEditItem Text="8" Value="7" />
                                                            <dx:ListEditItem Text="9" Value="8" />
                                                            <dx:ListEditItem Text="10" Value="9" />
                                                            <dx:ListEditItem Text="11" Value="10" />
                                                            <dx:ListEditItem Text="12" Value="11" />
                                                            <dx:ListEditItem Text="13" Value="12" />
                                                            <dx:ListEditItem Text="14" Value="13" />
                                                            <dx:ListEditItem Text="15" Value="14" />
                                                            <dx:ListEditItem Text="16" Value="15" />
                                                            <dx:ListEditItem Text="17" Value="16" />
                                                            <dx:ListEditItem Text="18" Value="17" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="ปีการผลิต" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxComboBox ID="cmbYear" runat="server">
                                                        <Items>
                                                            <dx:ListEditItem Text="2561/2562" Value="0" />
                                                            <dx:ListEditItem Text="2562/2563" Value="1" />
                                                            <dx:ListEditItem Text="2563/2564" Value="2" />
                                                            <dx:ListEditItem Text="2564/2565" Value="3" />
                                                        </Items>
                                                    </dx:ASPxComboBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="รหัสผู้พิมพ์บัตร" ColSpan="4">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtID" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="false" AllowPaging="True" CssClass="mygridview" OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="30px" DataField="Id" HeaderText="ลำดับที่" >
                                        <ItemStyle Width="30px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="30px" DataField="Code" HeaderText="เลขที่แปลง" >
                                        <ItemStyle Width="30px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:BoundField ItemStyle-Width="30px" DataField="PlName" HeaderText="ชื่อแปลง" >
                                        <ItemStyle Width="30px"></ItemStyle>
                                        </asp:BoundField>
                                        <asp:TemplateField ItemStyle-Width="30px" HeaderText="ชนิดอ้อย">
                                            <ItemTemplate>
                                                <div class="dropdown">
                                                    <asp:DropDownList runat="server" placeholder="ข้อมูลชนิดอ้อย" AutoPostBack="true" ID="cmbCanetype" CssClass="form-control">
                                                        <asp:ListItem Value="">-- เลือก --</asp:ListItem>
                                                        <asp:ListItem Value="อ้อยสด">อ้อยสด</asp:ListItem>
                                                        <asp:ListItem Value="อ้อยไฟไหม้">อ้อยไฟไหม้</asp:ListItem>
                                                        <asp:ListItem Value="อ้อยรถตัด">อ้อยรถตัด</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </ItemTemplate>
                                            <ItemStyle Width="30px"></ItemStyle>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <br />
                        <asp:Button ID="btnAccept" runat="server" OnClick="btnAccept_Click1" Text="ตกลง" />
                        <br />
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
    </p>
</asp:Content>
