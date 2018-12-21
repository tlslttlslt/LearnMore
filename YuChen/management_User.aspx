<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_User.aspx.cs" Inherits="management_Member" Title="管理用户" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>


<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <asp:GridView ID="grdViwUsers" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" >
        <Columns>
            <asp:TemplateField HeaderText="用户ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("userID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="用户名">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("userName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="地区">
                <ItemTemplate>
                    <asp:Label ID="lblUserZone" runat="server" Text='<%# Bind("userZone") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="邮箱">
                <ItemTemplate>
                    <asp:Label ID="lblUserEmail" runat="server" Text='<%# Bind("userEmail") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="权限">
                <ItemTemplate>
                    <asp:Label ID="lblUserRight" runat="server" Text='<%# Bind("userRight") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="修改权限">
                <ItemTemplate>
                    <asp:Button ID="btnUserRightModify" runat="server" CommandName='<%# Bind("userID") %>' Text="修改" OnClick="btnUserRightModify_Click" CommandArgument='<%# Bind("userRight") %>' CausesValidation="False" OnClientClick="return confirm('确定将此用户权限设为管理员吗？')" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除用户">
                <ItemTemplate>
                    <asp:Button ID="btnUserDelete" runat="server" CommandArgument='<%# Bind("userID") %>'
                        Text="删除" OnClick="btnUserDelete_Click" CausesValidation="False" OnClientClick='return confirm("确认删除此用户吗？")' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:Button ID="btnPnlUserAddDisplay" runat="server" Height="32px" OnClick="btnPnlUserAddDisplay_Click"
        Text="添加用户" CausesValidation="False" />
    <asp:Button ID="btnRefresh" runat="server" Height="32px" OnClick="btnRefresh_Click"
        Text="刷新" CausesValidation="False" />
    <br />
    <br />
    <asp:Panel ID="pnlUserAdd" runat="server" Height="264px" Visible="False"
        Width="432px">
        <table style="text-align: left">
            <tr>
                <td style="width: 87px; height: 21px; text-align: right;">
                    用户名：<br />
                    <br />
                </td>
                <td colspan="2" style="height: 21px">
                    <asp:TextBox ID="txtUserName" runat="server" Width="88px" ValidationGroup="userAdd"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqdFldVldtrUserName" runat="server" ControlToValidate="txtUserName"
                        ErrorMessage="用户名不能为空" Width="112px" ValidationGroup="userAdd"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rglExpVldtrUserName" runat="server" ErrorMessage="只能输入由数字、26个英文字母或者下划线组成的字符串" ControlToValidate="txtUserName" ValidationExpression="^\w+$" ValidationGroup="userAdd"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 87px; height: 23px; text-align: right;">
                    密码：<br />
                    <br />
                </td>
                <td colspan="2" style="height: 23px">
                    <asp:TextBox ID="txtUserPassword" runat="server" Width="88px" TextMode="Password" ValidationGroup="userAdd"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="reqdFldVldtrUserPassword" runat="server" ControlToValidate="txtUserPassword"
                        ErrorMessage="密码不能为空" ValidationGroup="userAdd"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rglExpVldtrUserPassword" runat="server" ControlToValidate="txtUserPassword"
                        ErrorMessage="以字母开头，长度在6~18之间，只能包含字符、数字和下划线" ValidationExpression="^[a-zA-Z]\w{5,17}$"
                        ValidationGroup="userAdd"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 87px; height: 18px; text-align: right;">
                    确认密码：</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    <asp:TextBox ID="txtUserPasswordConfig" runat="server" Width="88px" TextMode="Password" ValidationGroup="userAdd"></asp:TextBox>
                    <asp:CompareValidator ID="cprVldtrUserPasswordConfig" runat="server" ControlToCompare="txtUserPassword"
                        ControlToValidate="txtUserPasswordConfig" ErrorMessage="两次输入的密码不一致" ValidationGroup="userAdd"></asp:CompareValidator></td>
            </tr>
            <tr>
                <td style="width: 87px; height: 18px; text-align: right;">
                    地区：</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    <asp:DropDownList ID="DrpDwnLstUserZone" runat="server" ValidationGroup="userAdd">
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
                <td style="width: 87px; height: 18px; text-align: right;">
                    邮箱：<br />
                </td>
                <td colspan="2" style="height: 18px">
                    <asp:TextBox ID="txtUserEmail" runat="server" Width="88px" ValidationGroup="userAdd"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="reglExprVldtrUserEmail" runat="server" ControlToValidate="txtUserEmail"
                        ErrorMessage="邮箱格式不正确" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="userAdd"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrUserEmail" runat="server" ControlToValidate="txtUserEmail"
                        ErrorMessage="邮箱不能为空" ValidationGroup="userAdd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 87px; height: 18px; text-align: right;">
                    权限：</td>
                <td colspan="2" style="height: 18px; text-align: left">
                    <asp:DropDownList ID="drpDwnLstUserRight" runat="server" ValidationGroup="userAdd">
                        <asp:ListItem>用户</asp:ListItem>
                        <asp:ListItem>管理员</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 18px">
                    </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 18px; text-align: center;">
                    <asp:Button ID="btnUserAdd" runat="server" Height="32px" Text="添加" OnClick="btnUserAdd_Click" ValidationGroup="userAdd" OnClientClick="return confirm('确定添加用户吗？')" /></td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ConPlcHld_Copyright" Runat="Server">
</asp:Content>

