<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_InforDye.aspx.cs" Inherits="management_Member" Title="管理染料" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <asp:GridView ID="grdViwDye" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="440px" >
        <Columns>
            <asp:TemplateField HeaderText="染料ID">
                <ItemTemplate>
                    <asp:Label ID="lblDyeID" runat="server" Text='<%# Bind("dyeID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="lblDyeName" runat="server" Text='<%# Bind("dyeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="颜色">
                <ItemTemplate>
                    <asp:Label ID="lblDyeFrequency" runat="server" Text='<%# Bind("dyeColor") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存">
                <ItemTemplate>
                    <asp:Label ID="lblDyeStock" runat="server" Text='<%# Bind("dyeStock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:Button ID="btnDyeModify" runat="server" Text="修改" OnClick="btnDyeModify_Click" CommandArgument='<%# Bind("dyeID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:Button ID="btnDyeDelete" runat="server" CommandArgument='<%# Bind("dyeID") %>'
                        Text="删除" OnClick="btnDyeDelete_Click" OnClientClick="return confirm('确定删除此项？')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    &nbsp; &nbsp;&nbsp;
    <asp:Panel ID="pnlDyeAddModify" runat="server" Height="264px"
        Width="432px">
        <table style="text-align: left" id="tblDyeAddModify">
            <tr>
                <td style="width: 164px; height: 21px; text-align: right;">
                    肥料ID：</td>
                <td colspan="2" style="width: 413px; height: 21px">
                    <asp:Label ID="lblDyeID" runat="server" Width="112px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 21px; text-align: right;">
                    染料名称：<br />
                </td>
                <td colspan="2" style="width: 413px; height: 21px">
                    <asp:TextBox ID="txtDyeName" runat="server" Width="160px" ValidationGroup="dyeAddModify"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rqrFldVldtrDyeName" runat="server" ControlToValidate="txtDyeName"
                        ErrorMessage="名称不能为空" ValidationGroup="dyeAddModify"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 164px; height: 18px; text-align: right;">
                    颜色：<br />
                </td>
                <td colspan="2" style="width: 413px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtDyeColor" runat="server" ValidationGroup="dyeAddModify"></asp:TextBox>
                    <br />
                    <asp:RequiredFieldValidator ID="rqrFldVldtrDyeColor" runat="server" ControlToValidate="txtDyeColor"
                        ErrorMessage="请填入颜色" ValidationGroup="dyeAddModify"></asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td style="width: 164px; height: 18px; text-align: right;">
                    库存：<br />
                </td>
                <td colspan="2" style="width: 413px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtDyeStock" runat="server" ValidationGroup="dyeAddModify"></asp:TextBox><br />
                    <asp:RegularExpressionValidator
                        ID="rglExpDyeStock" runat="server" ControlToValidate="txtDyeStock"
                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*$" ValidationGroup="dyeAddModify"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrDyeStock" runat="server" ControlToValidate="txtDyeStock"
                        ErrorMessage="库存不能为空" ValidationGroup="dyeAddModify"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3" style="text-align: center;" rowspan="2">
                    <asp:Button ID="btnDyeAddModify" runat="server" Height="24px" Text="添加" OnClick="btnDyeAddModify_Click" ValidationGroup="dyeAddModify" />
    <asp:Button ID="btnDyeAdd" runat="server" OnClick="btnDyeAdd_Click"
        Text="添加新项" Width="72px" CausesValidation="False" ValidationGroup="dyeAddModify" /></td>
            </tr>
            <tr>
            </tr>
            <tr>
                <td colspan="3" rowspan="1" style="text-align: left">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ConPlcHld_Copyright" Runat="Server">
</asp:Content>

