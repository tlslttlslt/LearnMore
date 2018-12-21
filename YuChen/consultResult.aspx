<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="consultResult.aspx.cs" Inherits="consultResult" Title="咨询查看" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
    &nbsp;</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <br />
    <asp:GridView ID="grdViwConsultResult" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="624px">
        <Columns>
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
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:Button ID="btnConsultView" runat="server" CommandArgument='<%# Bind("consultID") %>'
                        OnClick="btnConsultView_Click" Text="查看" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <table style="text-align: left; width: 448px;">
        <tr>
            <td style="height: 21px">
                <br />
                标题：</td>
            <td colspan="5" style="width: 254px; height: 21px">
                <br />
                <asp:Label ID="lblConsultTitle" runat="server" Width="176px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 23px">
                ID:</td>
            <td colspan="5" style="width: 254px; height: 23px">
                <asp:Label ID="lblConsultID" runat="server" Width="128px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 23px">
                日期：</td>
            <td colspan="5" style="width: 254px; height: 23px">
                <asp:Label ID="lblConsultDate" runat="server" Width="128px"></asp:Label></td>
        </tr>
        <tr>
            <td style="height: 18px">
                内容：</td>
            <td colspan="5" rowspan="4" style="width: 254px; text-align: left">
                <asp:TextBox ID="txtConsultContent" runat="server" Height="112px" ReadOnly="True"
                    TextMode="MultiLine" Width="360px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td colspan="5" rowspan="1" style="width: 254px; text-align: left">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
                回答：</td>
            <td colspan="5" rowspan="4" style="width: 254px; text-align: left">
                <asp:TextBox ID="txtConsultAnswer" runat="server" Height="112px" TextMode="MultiLine"
                    Width="360px" ReadOnly="True"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
        </tr>
        <tr>
            <td style="height: 18px">
            </td>
            <td colspan="5" rowspan="1" style="width: 254px; text-align: left">
            </td>
        </tr>
    </table>
</asp:Content>

