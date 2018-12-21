<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="modify.aspx.cs" Inherits="modify" Title="用户信息修改" %>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <table style="width: 472px">
        <tr>
            <td colspan="1" style="width: 122px; text-align: center">
            </td>
            <td colspan="2" style="text-align: center">
                <br />
                <br />
                <br />
                <span style="font-size: 16pt">
                用户信息修改<br />
                    <br />
                </span>
            </td>
        </tr>
        <tr>
            <td style="width: 122px; text-align: right">
            </td>
            <td style="width: 95px; text-align: right">
                &nbsp; &nbsp; &nbsp; 用户名：</td>
            <td style="width: 151px; text-align: left;">
                <asp:Label ID="lblUserName" runat="server" BorderStyle="None" Font-Overline="False"
                    Font-Strikeout="False" Font-Underline="False" ForeColor="#0000C0" Height="24px"
                    Width="144px"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 122px; text-align: right">
            </td>
            <td style="width: 95px; text-align: right">
                旧密码：</td>
            <td style="width: 151px">
                <asp:TextBox ID="txtUserOldPassword" runat="server" TextMode="Password" Width="144px" ValidationGroup="userModify"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 122px; height: 21px; text-align: right">
            </td>
            <td style="width: 95px; height: 21px; text-align: right">
                新密码：</td>
            <td style="width: 151px; height: 21px">
                <asp:TextBox ID="txtUserNewPassword" runat="server" TextMode="Password" Width="144px" ValidationGroup="userModify"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 122px; text-align: right">
            </td>
            <td style="width: 95px; text-align: right">
                确认密码：</td>
            <td style="width: 151px; text-align: left">
                <asp:TextBox ID="txtUserNewPasswordConfig" runat="server" TextMode="Password" Width="144px" ValidationGroup="userModify"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 122px; text-align: right">
            </td>
            <td style="width: 95px; text-align: right">
                地区：</td>
            <td style="width: 151px; text-align: left">
                <asp:DropDownList ID="DrpDwnLstZone" runat="server" ValidationGroup="userModify">
                    <asp:ListItem Selected="True">东北</asp:ListItem>
                    <asp:ListItem>华北</asp:ListItem>
                    <asp:ListItem>西北</asp:ListItem>
                    <asp:ListItem>东南</asp:ListItem>
                    <asp:ListItem>西南</asp:ListItem>
                    <asp:ListItem>华南</asp:ListItem>
                    <asp:ListItem>大连</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 122px">
            </td>
            <td colspan="2">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Width="264px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="1" style="width: 122px; text-align: center">
            </td>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" Text="修改" ValidationGroup="userModify" />
                <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置" ValidationGroup="userModify" /></td>
        </tr>
    </table>
</asp:Content>

