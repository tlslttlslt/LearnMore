<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_InforFertilizer.aspx.cs" Inherits="management_Member" Title="管理肥料" EnableEventValidation = "false"%>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <asp:GridView ID="grdViwFertilizer" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Width="704px" >
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
                <ControlStyle Width="100px" />
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
                <ControlStyle Width="30px" />
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
                <ControlStyle Width="150px" />
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
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:Button ID="btnFertilizerModify" runat="server" Text="修改" OnClick="btnFertilizerModify_Click" CommandArgument='<%# Bind("fertilizerID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除">
                <ItemTemplate>
                    <asp:Button ID="btnFertilizerDelete" runat="server" CommandArgument='<%# Bind("fertilizerID") %>'
                        Text="删除" OnClick="btnFertilizerDelete_Click" OnClientClick="return confirm('确认删除此项？')" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    &nbsp; &nbsp;&nbsp;
    <asp:Panel ID="pnlFertilizerAddModify" runat="server" Height="264px"
        Width="432px">
        <table style="text-align: left" id="tblFertilizerAddModify">
            <tr>
                <td style="width: 108px; height: 21px; text-align: right;">
                    肥料ID：</td>
                <td colspan="2" style="width: 324px; height: 21px">
                    <asp:Label ID="lblFertilizerID" runat="server" Width="112px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 21px; text-align: right;">
                    肥料名称：</td>
                <td colspan="2" style="width: 324px; height: 21px">
                    <asp:TextBox ID="txtFertilizerName" runat="server" Width="160px" ValidationGroup="fertilizerAddModify"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrFertilizerName" runat="server" ErrorMessage="名称不能为空"
                        ValidationGroup="fertilizerAddModify" ControlToValidate="txtFertilizerName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 23px; text-align: right;">
                    是否复合肥：</td>
                <td colspan="2" style="width: 324px; height: 23px">
                    &nbsp;<asp:RadioButton ID="radBtnFertilizerCompound1" runat="server" Text="是" GroupName="radBtnFertilizerCompound" Checked="True" ValidationGroup="fertilizerAddModify" />
                    <asp:RadioButton ID="radBtnFertilizerCompound0" runat="server" Text="否" GroupName="radBtnFertilizerCompound" ValidationGroup="fertilizerAddModify" /></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    是否有机肥：</td>
                <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                    &nbsp;<asp:RadioButton ID="radBtnFertilizerOrganic1" runat="server" Text="是" GroupName="radBtnFertilizerOrganic" Checked="True" ValidationGroup="fertilizerAddModify" />
                    <asp:RadioButton
                        ID="radBtnFertilizerOrganic0" runat="server" Text="否" GroupName="radBtnFertilizerOrganic" ValidationGroup="fertilizerAddModify" /></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    是否追肥：</td>
                <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                    &nbsp;<asp:RadioButton ID="radBtnFertilizerAfter1" runat="server" Text="是" GroupName="radBtnFertilizerAfter" Checked="True" ValidationGroup="fertilizerAddModify" />
                    <asp:RadioButton ID="radBtnFertilizerAfter0"
                        runat="server" Text="否" GroupName="radBtnFertilizerAfter" ValidationGroup="fertilizerAddModify" /></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    稀释倍数：<br />
                </td>
                <td colspan="2" style="width: 324px; height: 18px">
                    <asp:TextBox ID="txtFertilizerDilute" runat="server" ValidationGroup="fertilizerAddModify"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrFertilizerDilute" runat="server" ErrorMessage="请填入稀释倍数"
                        ValidationGroup="fertilizerAddModify" ControlToValidate="txtFertilizerDilute"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rglExpVldtrFertilizerDilute" runat="server" ControlToValidate="txtFertilizerDilute"
                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*$" ValidationGroup="fertilizerAddModify"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    有效成分：</td>
                <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtFertilizerIngredient" runat="server" ValidationGroup="fertilizerAddModify"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrFertilzerIngredient" runat="server" ErrorMessage="请填入有效成分"
                        ValidationGroup="fertilizerAddModify" ControlToValidate="txtFertilizerIngredient"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 1px; text-align: right;">
                    适宜土壤：</td>
                <td colspan="2" style="width: 324px; height: 1px; text-align: left">
                    <asp:DropDownList ID="drpDwnLstFertilizerSoil" runat="server" ValidationGroup="fertilizerAddModify">
                        <asp:ListItem Selected="True">东北黑土地</asp:ListItem>
                        <asp:ListItem>盐碱地</asp:ListItem>
                        <asp:ListItem>酸性土壤</asp:ListItem>
                        <asp:ListItem>碱性土壤</asp:ListItem>
                        <asp:ListItem>旱田</asp:ListItem>
                        <asp:ListItem Value="水田">水田</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    施肥频率：<br />
                </td>
                <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtFertilizerFrequency" runat="server" ValidationGroup="fertilizerAddModify"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrFertilzerFrequency" runat="server" ErrorMessage="请填入施肥频率"
                        ValidationGroup="fertilizerAddModify" ControlToValidate="txtFertilizerFrequency"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rglExpVldtrFertilizerFerquency" runat="server" ControlToValidate="txtFertilizerFrequency"
                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*$" ValidationGroup="fertilizerAddModify"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td style="width: 108px; height: 18px; text-align: right;">
                    库存：<br />
                </td>
                <td colspan="2" style="width: 324px; height: 18px; text-align: left">
                    <asp:TextBox ID="txtFertilizerStock" runat="server" ValidationGroup="fertilizerAddModify"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rqrFldVldtrFertilizerStock" runat="server" ErrorMessage="请填入库存"
                        ValidationGroup="fertilizerAddModify" ControlToValidate="txtFertilizerStock"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="rglExpVldtrFertilizerStock" runat="server" ControlToValidate="txtFertilizerStock"
                        ErrorMessage="请输入数字" ValidationExpression="^[0-9]*$" ValidationGroup="fertilizerAddModify"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td colspan="3" style="height: 18px">
                    </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 18px; text-align: center;">
                    <asp:Button ID="btnFertilizerAddModify" runat="server" Height="24px" Text="添加" OnClick="btnFertilizerAddModify_Click" ValidationGroup="fertilizerAddModify" />
    <asp:Button ID="btnFertilizerAdd" runat="server" OnClick="btnFertilizerAdd_Click"
        Text="添加新项" Width="72px" ValidationGroup="fertilizerAddModify" CausesValidation="False" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="ConPlcHld_Copyright" Runat="Server">
</asp:Content>

