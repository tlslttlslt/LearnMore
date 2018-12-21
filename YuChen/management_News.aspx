<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_News.aspx.cs" Inherits="management_Member" Title="管理新闻" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <asp:GridView ID="grdViwNews" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="536px" >
        <Columns>
            <asp:TemplateField HeaderText="新闻ID">
                <ItemTemplate>
                    <asp:Label ID="lblNewsID" runat="server" Text='<%# Bind("newsID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标题">
                <ItemTemplate>
                    <asp:Label ID="lblNewsTitle" runat="server" Text='<%# Bind("newsTitle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="日期">
                <ItemTemplate>
                    &nbsp;<asp:Label ID="lblNewsDate" runat="server" Text='<%# Bind("newsDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑">
                <ItemTemplate>
                    <asp:Button ID="btnNewsModify" runat="server" CommandArgument='<%# Bind("newsID") %>'
                        OnClick="btnNewsModify_Click" Text="编辑" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:Button ID="btnNewsDelete" runat="server" CommandArgument='<%# Bind("newsID") %>'
                        OnClick="btnNewsDelete_Click" Text="删除" OnClientClick="return confirm('你要执行这个操作吗？')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnNewsAdd" runat="server" OnClick="btnNewsAdd_Click" Text="添加新项" /><br />
    <br />
        <table style="text-align: left">
            <tr>
                <td style="width: 51px; height: 21px">
                    标题：</td>
                <td colspan="5" style="width: 472px; height: 21px">
                    <asp:TextBox ID="txtNewsTitle" runat="server" Width="296px" ReadOnly="True" ValidationGroup="newsAdd"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrNewsTitle" runat="server" ErrorMessage="标题不能为空" ControlToValidate="txtNewsTitle" ValidationGroup="newsAdd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 51px; height: 23px">
                    ID:</td>
                <td colspan="5" style="width: 472px; height: 23px">
                    <asp:Label ID="lblNewsID" runat="server" Width="128px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 51px; height: 23px">
                    日期：</td>
                <td colspan="5" style="width: 472px; height: 23px">
                    <asp:Label ID="lblNewsDate" runat="server" Width="128px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 51px; height: 18px">
                    内容：</td>
                <td colspan="5" style="width: 472px; text-align: left" rowspan="4">
                    <asp:TextBox ID="txtNewsContent" runat="server" Height="232px" ReadOnly="True"
                        TextMode="MultiLine" Width="448px" ValidationGroup="newsAdd"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 51px; height: 18px">
                    <asp:RequiredFieldValidator ID="rqrFldVldtrNewsContent" runat="server" ErrorMessage="内容不能为空" ControlToValidate="txtNewsContent" ValidationGroup="newsAdd"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 51px; height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 51px; height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 51px; height: 18px">
                </td>
                <td colspan="5" rowspan="1" style="width: 472px; text-align: left">
                    <asp:Button ID="btnNewsModifyAddSubmit" runat="server" OnClick="btnNewsModifyAddSubmit_Click"
                        Text="修改" ValidationGroup="newsAdd" /></td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ConPlcHld_Copyright" Runat="Server">
</asp:Content>

