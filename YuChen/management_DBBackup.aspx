<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_DBBackup.aspx.cs" Inherits="management_DBBackup" Title="数据库备份" %>
<%@ MasterType VirtualPath ="~/MasterPageManager.master" %>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <br />
    <asp:Button ID="btnDBBackup" runat="server" OnClick="btnDBBackup_Click" Text="备份" />
    <br />
    <asp:Button ID="btnDBRecovery" runat="server" OnClick="btnDBRecovery_Click" Text="还原" OnClientClick="return confirm('请关闭一切数据库链接，否则会导致错误。确认恢复数据库吗？')" />
</asp:Content>

