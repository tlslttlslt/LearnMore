<%@ Page Language="C#" MasterPageFile="~/MasterPageManager.master" AutoEventWireup="true" CodeFile="management_Search.aspx.cs" Inherits="management_Search" Title="管理员查找" %>
<%@ MasterType VirtualPath="~/MasterPageManager.master"%>

<asp:Content ID="Content3" ContentPlaceHolderID="ConPlcHld_Center" Runat="Server">
    <br />
    <br />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 536px">
        <tr>
            <td style="width: 106px; height: 46px">
                关键字：</td>
            <td style="width: 328px; height: 46px; text-align: left">
                <asp:TextBox ID="txtKeyword" runat="server" Height="16px" Width="200px"></asp:TextBox></td>
            <td style="width: 100px; height: 46px">
            </td>
        </tr>
        <tr>
            <td style="width: 106px; height: 38px">
                用户查询：</td>
            <td style="width: 328px; height: 38px; text-align: left">
                <asp:RadioButton ID="RadBtnSearchUserID" runat="server" GroupName="radBtnSearchUser"
                    Text="ID" />
                <asp:RadioButton ID="RadBtnSearchUserName" runat="server" GroupName="radBtnSearchUser"
                    Text="用户名" />
                <asp:RadioButton ID="RadBtnSearchUserEmail" runat="server" GroupName="radBtnSearchUser"
                    Text="Email" /></td>
            <td style="width: 100px; height: 38px">
                <asp:Button ID="btnSearchUser" runat="server" OnClick="btnSearchUser_Click" Text="查找用户" /></td>
        </tr>
        <tr>
            <td style="width: 106px; height: 41px">
                新闻查询：</td>
            <td style="width: 328px; height: 41px; text-align: left">
                <asp:RadioButton ID="radBtnSearchNewsID" runat="server" GroupName="radBtnSearchNews"
                    Text="ID" />
                <asp:RadioButton ID="radBtnSearchNewsTitle" runat="server" GroupName="radBtnSearchNews"
                    Text="标题" />
                <asp:RadioButton ID="radBtnSearchNewsContent" runat="server" GroupName="radBtnSearchNews"
                    Text="内容" /></td>
            <td style="width: 100px; height: 41px">
                <asp:Button ID="btnSearchNews" runat="server" OnClick="btnSearchNews_Click" Text="查找新闻" /></td>
        </tr>
        <tr>
            <td style="width: 106px; height: 39px">
                染料查询：</td>
            <td style="width: 328px; height: 39px; text-align: left">
                <asp:RadioButton ID="radBtnSearchDyeID" runat="server" GroupName="radBtnSearchDye"
                    Text="ID" /><asp:RadioButton ID="radBtnSearchDyeName" runat="server" GroupName="radBtnSearchDye"
                        Text="名称" /><asp:RadioButton ID="radBtnSearchDyeColor" runat="server" GroupName="radBtnSearchDye"
                            Text="颜色" /></td>
            <td style="width: 100px; height: 39px">
                <asp:Button ID="btnSearchDye" runat="server" OnClick="btnSearchDye_Click" Text="查找染料" /></td>
        </tr>
        <tr>
            <td style="width: 106px; height: 38px">
                肥料查询：</td>
            <td style="width: 328px; height: 38px; text-align: left">
                <asp:RadioButton ID="radBtnSearchFertilizerID" runat="server" GroupName="radBtnSearchFertilizer"
                    Text="ID" /><asp:RadioButton ID="radBtnSearchFertilizerName" runat="server" GroupName="radBtnSearchFertilizer"
                        Text="名称" /></td>
            <td style="width: 100px; height: 38px">
                <asp:Button ID="btnSearchFertilizer" runat="server" OnClick="btnSearchFertilizer_Click"
                    Text="查找肥料" /></td>
        </tr>
        <tr>
            <td style="width: 106px; height: 42px">
                咨询查询：</td>
            <td style="width: 328px; height: 42px; text-align: left">
                <asp:RadioButton ID="radBtnSearchConsultID" runat="server" GroupName="radBtnSearchConsult"
                    Text="ID" />
                <asp:RadioButton ID="radBtnSearchConsultTitle" runat="server" GroupName="radBtnSearchConsult"
                    Text="标题" />
                <asp:RadioButton ID="radBtnSearchConsultConcent" runat="server" GroupName="radBtnSearchConsult"
                    Text="内容" />&nbsp;
                <asp:RadioButton ID="radBtnSearchConsultAnswer" runat="server" GroupName="radBtnSearchConsult"
                    Text="回答" />
                <asp:RadioButton ID="radBtnSearchConsultUserID" runat="server" GroupName="radBtnSearchConsult"
                    Text="提问者ID" /></td>
            <td style="width: 100px; height: 42px">
                <asp:Button ID="btnSearchConsult" runat="server" OnClick="btnSearchConsult_Click"
                    Text="查找咨询" /></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grdViwUsers" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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
                    <asp:Button ID="btnUserRightModify" runat="server" CausesValidation="False" CommandArgument='<%# Bind("userRight") %>'
                        CommandName='<%# Bind("userID") %>' OnClick="btnUserRightModify_Click" OnClientClick="return confirm('确定将此用户权限设为管理员吗？')"
                        Text="修改" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除用户">
                <ItemTemplate>
                    <asp:Button ID="btnUserDelete" runat="server" CausesValidation="False" CommandArgument='<%# Bind("userID") %>'
                        OnClick="btnUserDelete_Click" OnClientClick='return confirm("确认删除此用户吗？")' Text="删除" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grdViwNews" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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
            <asp:TemplateField HeaderText="管理">
                <ItemTemplate>
                    <asp:Button ID="btnManagementNews" runat="server" CommandArgument='<%# Bind("newsID") %>'
                        OnClick="btnManagementNews_Click" Text="管理新闻" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grdViwFertilizer" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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
            <asp:TemplateField HeaderText="转到修改">
                <ItemTemplate>
                    <asp:Button ID="btnManagementFertilizer" runat="server" CommandArgument='<%# Bind("fertilizerID") %>'
                        OnClick="btnManagementFertilizer_Click" Text="修改" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grdViwDye" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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
            <asp:TemplateField HeaderText="修改">
                <ItemTemplate>
                    <asp:Button ID="btnManagementDye" runat="server" CommandArgument='<%# Bind("dyeID") %>'
                        OnClick="btnManagementDye_Click" Text="修改" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
    <asp:GridView ID="grdViwConsult" runat="server" AutoGenerateColumns="False" Visible="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None">
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
            <asp:TemplateField HeaderText="转到管理">
                <ItemTemplate>
                    <asp:Button ID="btnManagementConsult" runat="server" CommandArgument='<%# Bind("consultID") %>'
                        OnClick="btnManagementConsult_Click" Text="管理" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
    </asp:GridView>
    <br />
</asp:Content>

