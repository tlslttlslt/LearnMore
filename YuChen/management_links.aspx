<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_links.aspx.cs" Inherits="management_links" Title="管理链接" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <asp:GridView ID="grdViwLinks" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="700px">
        <Columns>
            <asp:TemplateField HeaderText="链接ID">
                <ItemTemplate>
                    <asp:Label ID="lblLinkID" runat="server" Text='<%# Bind("linkID") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkBtnLinkName" runat="server"
                        Text='<%# Bind("linkName") %>' CommandArgument='<%# Bind("linkURl") %>' OnClick="lnkBtnLinkName_Click"></asp:LinkButton>
                </ItemTemplate>
                <ControlStyle Width="100px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="URL">
                <ItemTemplate>
                    <asp:Label ID="lblLinkURL" runat="server" Text='<%# Bind("linkURL") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="说明">
                <ItemTemplate>
                    <asp:Label ID="lblLinkContent" runat="server" Text='<%# Bind("linkContent") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <asp:Button ID="btnLinkModify" runat="server" CommandArgument='<%# Bind("linkID") %>'
                        Text="编辑" OnClick="btnLinkModify_Click" />
                </ItemTemplate>
                <ControlStyle Width="50px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:Button ID="btnLinkDelete" runat="server" CommandArgument='<%# Bind("linkID") %>'
                        Text="删除" OnClick="btnLinkDelete_Click" OnClientClick='return confirm("真的要删除此链接吗？")' />
                </ItemTemplate>
                <ControlStyle Width="50px" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:Button ID="btnLinkAdd" runat="server" Text="添加新项" OnClick="btnLinkAdd_Click" /><br />
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="height: 8px">
        <tr>
            <td style="width: 100px; text-align: right;">
                链接ID：</td>
            <td style="width: 100px">
                <asp:Label ID="lblLinkID" runat="server" Width="112px"></asp:Label></td>
            <td style="width: 146px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 24px; text-align: right;">
                URL：</td>
            <td style="width: 100px; height: 24px;">
                <asp:TextBox ID="txtLinkURL" runat="server" ValidationGroup="linkAddModify"></asp:TextBox></td>
            <td style="width: 146px; height: 24px;">
                <asp:RequiredFieldValidator ID="rqrFldVldtrLinkURL" runat="server" ErrorMessage="网址不可为空" ControlToValidate="txtLinkURL" ValidationGroup="linkAddModify"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rglrExpVldtrLinkURL" runat="server" ErrorMessage="网址格式不正确！" ControlToValidate="txtLinkURL" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?" ValidationGroup="linkAddModify"></asp:RegularExpressionValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px; text-align: right;">
                名称：</td>
            <td style="width: 100px; height: 19px;">
                <asp:TextBox ID="txtLinkName" runat="server" ValidationGroup="linkAddModify"></asp:TextBox></td>
            <td style="width: 146px; height: 19px;">
                <asp:RequiredFieldValidator ID="rqrFldVldtrLinkName" runat="server" ErrorMessage="链接名称不可为空" ControlToValidate="txtLinkName" ValidationGroup="linkAddModify"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px; text-align: right;">
                说明：</td>
            <td style="width: 100px; height: 19px;">
                <asp:TextBox ID="txtLinkContent" runat="server" ValidationGroup="linkAddModify"></asp:TextBox></td>
            <td style="width: 146px; height: 19px;">
            </td>
        </tr>
        <tr>
            <td style="width: 100px; height: 19px;">
            </td>
            <td style="width: 100px; height: 19px;">
                <asp:Button ID="btnLinkModifyAddSubmit" runat="server" Text="修改" OnClick="btnLinkModifyAddSubmit_Click" ValidationGroup="linkAddModify" /></td>
            <td style="width: 146px; height: 19px;">
            </td>
        </tr>
    </table>
    <br />
    <br />
</asp:Content>

