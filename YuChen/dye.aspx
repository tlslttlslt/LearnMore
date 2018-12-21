<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="dye.aspx.cs" Inherits="dye" Title="印花染料介绍" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server" >
    <br />
    <br />
    <br />
    <br />
    <br />
    <asp:GridView ID="grdViwDye" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="632px">
        <Columns>
            <asp:TemplateField HeaderText="染料ID">
                <ItemTemplate>
                    <asp:Label ID="lblDyeID" runat="server" Text='<%# Bind("dyeID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="染料名称">
                <ItemTemplate>
                    <asp:Label ID="lblDyeName" runat="server" Text='<%# Bind("dyeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="颜色">
                <ItemTemplate>
                    <asp:Label ID="lblDyeColor" runat="server" Text='<%# Bind("dyeColor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存">
                <ItemTemplate>
                    <asp:Label ID="lblDyeStock" runat="server" Text='<%# Bind("dyeStock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="咨询">
                <ItemTemplate>
                    <asp:Button ID="btnDyeConsult" runat="server" CommandArgument='<%# Bind("dyeName") %>'
                        OnClick="btnDyeConsult_Click" Text="咨询" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
    &nbsp;</asp:Content>

