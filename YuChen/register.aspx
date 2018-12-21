<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" Title="注册" %>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <table style="width: 336px">
        <tr>
            <td colspan="2" style="text-align: center">
                <br />
                <br />
                <br />
                <span style="font-size: 30px">
                用户注册</span></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                用户名：</td>
            <td style="width: 151px; text-align: left;">
                <asp:TextBox ID="txtUserName" runat="server" Width="144px" ValidationGroup="userRegister"></asp:TextBox>&nbsp;
            </td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                密码：</td>
            <td style="width: 151px">
                <asp:TextBox ID="txtUserPassword" runat="server" TextMode="Password" Width="144px" ValidationGroup="userRegister"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; height: 21px; text-align: right">
                确认密码：</td>
            <td style="width: 151px; height: 21px">
                <asp:TextBox ID="txtUserPasswordConfig" runat="server" TextMode="Password" Width="144px" ValidationGroup="userRegister"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="width: 120px; text-align: right">
                地区：</td>
            <td style="width: 151px; text-align: left;">
                <asp:DropDownList ID="DrpDwnLstZone" runat="server" ValidationGroup="userRegister">
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
            <td style="width: 120px; text-align: right">
                邮箱：</td>
            <td style="width: 151px">
                <asp:TextBox ID="txtUserEmail" runat="server" Width="144px" ValidationGroup="userRegister"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Width="264px"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2" style="text-align: center">
                <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="注册" ValidationGroup="userRegister" />
                <asp:Button ID="btnReset" runat="server" Text="重置" OnClick="btnReset_Click" ValidationGroup="userRegister" /></td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    &nbsp;
</asp:Content>

