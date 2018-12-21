<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="searchResult.aspx.cs" Inherits="searchResult" Title="搜索结果" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    &nbsp;<asp:GridView ID="grdViwFertilizer" runat="server" AutoGenerateColumns="False"
        BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2"
        ForeColor="Black" GridLines="None" Visible="False" Width="480px">
        <FooterStyle BackColor="Tan" />
        <Columns>
            <asp:TemplateField HeaderText="肥料ID">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerID" runat="server" Text='<%# Bind("fertilizerID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="名称">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerName" runat="server" Text='<%# Bind("fertilizerName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="复合">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerCompound" runat="server" Text='<%# Bind("fertilizerCompound") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="有机">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerOrganic" runat="server" Text='<%# Bind("fertilizerOrganic") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="追肥">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerAfter" runat="server" Text='<%# Bind("fertilizerAfter") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="稀释倍数">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerDilute" runat="server" Text='<%# Bind("fertilizerDilute") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="成份">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerIngredient" runat="server" Text='<%# Bind("fertilizerIngredient") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="土壤">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerSoil" runat="server" Text='<%# Bind("fertilizerSoil") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="频率">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerFrequency" runat="server" Text='<%# Bind("fertilizerFrequency") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="库存">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerStock" runat="server" Text='<%# Bind("fertilizerStock") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="咨询">
                <ItemTemplate>
                    <asp:Button ID="btnConsultFertilizer" runat="server" CommandArgument='<%# Bind("fertilizerName") %>'
                        OnClick="btnConsultFertilizer_Click" Text="咨询" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:GridView ID="grdViwDye" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
        Visible="False" Width="496px">
        <FooterStyle BackColor="Tan" />
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
            <asp:TemplateField HeaderText="咨询">
                <ItemTemplate>
                    <asp:Button ID="btnConsultDye" runat="server" CommandArgument='<%# Bind("dyeName") %>'
                        OnClick="btnConsultDye_Click" Text="咨询" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:GridView ID="grdViwConsult" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
        Visible="False" Width="496px">
        <FooterStyle BackColor="Tan" />
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
            <asp:TemplateField HeaderText="查看">
                <ItemTemplate>
                    <asp:Button ID="btnConsultView" runat="server" CommandArgument='<%# Bind("consultID") %>'
                        OnClick="btnConsultView_Click" Text="查看" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <asp:Panel ID="pnlConsultView" runat="server" Height="50px" Width="384px" Visible="False">
        <br />
        <table>
            <tr>
                <td style="text-align: right;">
                    <br />
                    题目：</td>
                <td style="text-align: left;">
                    <br />
                    <asp:Label ID="lblConsultTitle" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    所属：</td>
                <td style="text-align: left;">
                    <asp:Label ID="lblConsultSort" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    提问日期：</td>
                <td style="text-align: left;">
                    <asp:Label ID="lblConsultDate" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    内容：</td>
                <td>
                    <asp:TextBox ID="txtConsultContent" runat="server" TextMode="MultiLine" Height="128px" Width="288px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align: right;">
                    回答：</td>
                <td>
                    <asp:TextBox ID="txtConsultAnswer" runat="server" ReadOnly="True" TextMode="MultiLine" Height="136px" Width="288px"></asp:TextBox></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblSearchNoResult" runat="server" Visible="False" Width="224px"></asp:Label>
    <br />
</asp:Content>

