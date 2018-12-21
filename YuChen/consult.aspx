<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="consult.aspx.cs" Inherits="consult" Title="业务咨询" %>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
    &nbsp;</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <table id="tblFertilizerAddModify" style="text-align: left">
        <tr>
            <td colspan="3" style="height: 21px; text-align: center">
                <strong><span style="font-size: 24pt; font-family: 方正瘦金书简体">
                    <br />
                    业务咨询<br />
                </span></strong></td>
        </tr>
        <tr>
            <td style="width: 108px; height: 21px">
                咨询主题：</td>
            <td colspan="2" style="width: 324px; height: 21px">
                <asp:TextBox ID="txtConsultTitle" runat="server" Width="160px" ValidationGroup="consult"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RqrFldVldtConsultTitle" runat="server" ControlToValidate="txtConsultTitle"
                    ErrorMessage="标题不能为空" ValidationGroup="consult"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 108px; height: 23px">
                咨询分类：</td>
            <td colspan="2" style="width: 324px; height: 23px">
                &nbsp;<asp:RadioButton ID="radBtnConsultSortFertilizer" runat="server" GroupName="radBtnConsultSort"
                    Text="肥料" Checked="True" ValidationGroup="consult" />
                <asp:RadioButton ID="radBtnConsultSortDye" runat="server" GroupName="radBtnConsultSort"
                    Text="染料" ValidationGroup="consult" /></td>
        </tr>
        <tr>
            <td style="width: 108px; height: 18px">
                是否公开：</td>
            <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                &nbsp;<asp:RadioButton ID="radBtnConsultPrivate0" runat="server" GroupName="radBtnConsultPrivate"
                    Text="公开" Checked="True" ValidationGroup="consult" />
                <asp:RadioButton ID="radBtnConsultPrivate1" runat="server" GroupName="radBtnConsultPrivate"
                    Text="私有" ValidationGroup="consult" /></td>
        </tr>
        <tr>
            <td colspan="3" rowspan="7">
                <asp:TextBox ID="txtConsultContent" runat="server" Height="224px" TextMode="MultiLine"
                    Width="528px" ValidationGroup="consult"></asp:TextBox></td>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
        </tr>
        <tr>
            <td colspan="3" style="height: 18px; text-align: center">
                <asp:RequiredFieldValidator ID="RqrFldVldtConsultContent" runat="server" ControlToValidate="txtConsultContent"
                    ErrorMessage="内容不能为空" ValidationGroup="consult"></asp:RequiredFieldValidator><br />
                <asp:Button ID="btnConsultSubmit" runat="server" Height="24px" OnClick="btnConsultSubmit_Click"
                    Text="提交" ValidationGroup="consult" />
            </td>
        </tr>
    </table>
</asp:Content>

