<%@ Page Language="C#" MasterPageFile="~/MasterPageUser.master" AutoEventWireup="true" CodeFile="fertilizer.aspx.cs" Inherits="dye" Title="液体有机肥介绍" EnableEventValidation="false"%>
<%@ MasterType VirtualPath="~/MasterPageUser.master"%>
<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <asp:GridView ID="grdViwFertilizer" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="680px">
        <Columns>
            <asp:TemplateField HeaderText="肥料ID">
                <ItemTemplate>
                    <asp:Label ID="lblFertilizerID" runat="server" Text='<%# Bind("fertilizerID") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="50px" />
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
                    <asp:Button ID="btnFertilizerConsult" runat="server" CommandArgument='<%# Bind("fertilizerName") %>'
                        OnClick="btnFertilizerConsult_Click" Text="咨询" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="ConPlcHld_RightUp">
    &nbsp;</asp:Content>

