<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_Consult.aspx.cs" Inherits="management_Member" Title="管理咨询" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <br />
    <asp:GridView ID="grdViwConsult" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="688px" >
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                    <asp:Label ID="lblConsultID" runat="server" Text='<%# Bind("consultID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="种类">
                <ItemTemplate>
                    <asp:Label ID="lblConsultSort" runat="server" Text='<%# Bind("consultSort") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="标题">
                <ItemTemplate>
                    <asp:Label ID="lblConsultTitle" runat="server" Text='<%# Bind("consultTitle") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="公开性">
                <ItemTemplate>
                    <asp:Label ID="lblConsultPrivate" runat="server" Text='<%# Bind("consultPrivate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="已回答">
                <ItemTemplate>
                    <asp:Label ID="lblcConsultAnswered" runat="server" Text='<%# Bind("consultAnswered") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="提问者ID">
                <ItemTemplate>
                    <asp:Label ID="lblUserID" runat="server" Text='<%# Bind("userID") %>'></asp:Label>&nbsp;
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="日期">
                <ItemTemplate>
                    &nbsp;<asp:Label ID="lblConsultDate" runat="server" Text='<%# Bind("consultDate") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="回答">
                <ItemTemplate>
                    <asp:Button ID="btnConsultAnswer" runat="server" CommandArgument='<%# Bind("consultID") %>'
                        OnClick="btnConsultAnswer_Click" Text="回答" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:Button ID="btnConsultDelete" runat="server" CommandArgument='<%# Bind("consultID") %>'
                        OnClick="btnConsultDelete_Click" Text="删除" OnClientClick='return confirm("你确定要删除此咨询吗？")' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    &nbsp;&nbsp;
    <br />
        <table style="text-align: left">
            <tr>
                <td style="width: 88px; height: 21px">
                    标题：</td>
                <td colspan="5" style="width: 355px; height: 21px">
                    <asp:Label ID="lblConsultTitle" runat="server" Width="176px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 88px; height: 23px">
                    ID:</td>
                <td colspan="5" style="width: 355px; height: 23px">
                    <asp:Label ID="lblConsultID" runat="server" Width="128px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 88px; height: 23px">
                    日期：</td>
                <td colspan="5" style="width: 355px; height: 23px">
                    <asp:Label ID="lblConsultDate" runat="server" Width="128px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                    内容：</td>
                <td colspan="5" style="width: 355px; text-align: left" rowspan="4">
                    <asp:TextBox ID="txtConsultContent" runat="server" Height="112px" ReadOnly="True"
                        TextMode="MultiLine" Width="512px" ValidationGroup="answerConsult"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                    </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                </td>
                <td colspan="5" rowspan="1" style="width: 355px; text-align: left">
                </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                    回答：</td>
                <td colspan="5" rowspan="4" style="width: 355px; text-align: left">
                    <asp:TextBox ID="txtConsultAnswer" runat="server" Height="112px" TextMode="MultiLine"
                        Width="512px" Enabled="False" ValidationGroup="answerConsult"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 88px; height: 37px">
                    </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                </td>
            </tr>
            <tr>
                <td style="width: 88px; height: 18px">
                </td>
                <td colspan="5" rowspan="1" style="width: 355px; text-align: left">
                    <asp:Button ID="btnConsultAnswerSubmit" runat="server" OnClick="btnConsultAnswerSubmit_Click"
                        Text="提交" ValidationGroup="answerConsult" /></td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ConPlcHld_Copyright" Runat="Server">
</asp:Content>

