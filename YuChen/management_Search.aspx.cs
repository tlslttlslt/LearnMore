using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;


public partial class management_Search : System.Web.UI.Page
{
    string strSqlCmd;
    DataSet DS;


    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userRight"] == null || !Session["userRight"].ToString().Equals("1"))
        {

            Response.Write(" <script   language=\"javascript\"> alert(\"对不起,你无此权限。请返回首页登录。\");window.location.href='Default.aspx'</script> ");

        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }

    }
    protected void btnSearchUser_Click(object sender, EventArgs e)
    {
        grdViwConsult.Visible = false;
        grdViwDye.Visible = false;
        grdViwFertilizer.Visible = false;
        grdViwNews.Visible = false;
        grdViwUsers.Visible = false;
               
        if (radBtnSearchConsultUserID.Checked)
        {
            strSqlCmd = "select * from users where userID = '" + txtKeyword.Text + "'";
        }
        else if (RadBtnSearchUserName.Checked)
        {
            strSqlCmd = "select * from users where userName = '" + txtKeyword.Text + "'";
        }
        else 
        {
            strSqlCmd = "select * from users where userEmail = '" + txtKeyword.Text + "'";
        }

        DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResultUsers");


        for (int i = 0; i < DS.Tables["searchResultUsers"].Rows.Count; i++)
        {
            if (DS.Tables["searchResultUsers"].Rows[i][6].ToString().Equals("0"))
            {
                DS.Tables["searchResultUsers"].Rows[i][6] = (string)"用户";
            }
            else
            {
                DS.Tables["searchResultUsers"].Rows[i][6] = (string)"管理员";
            }

        }

        grdViwUsers.DataSource = DS;
        grdViwUsers.DataBind();
        grdViwUsers.Visible = true;

    }
    protected void btnSearchNews_Click(object sender, EventArgs e)
    {
        grdViwConsult.Visible = false;
        grdViwDye.Visible = false;
        grdViwFertilizer.Visible = false;
        grdViwNews.Visible = false;
        grdViwUsers.Visible = false;

        if (radBtnSearchNewsID.Checked)
        {
            strSqlCmd = "select * from news where newsID = '" + txtKeyword.Text + "'";
        }
        else if (radBtnSearchNewsTitle.Checked)
        {
            strSqlCmd = "select * from news where newsTitle like '%" + txtKeyword.Text + "%'";
        }
        else
        {
            strSqlCmd = "select * from news where newsContent like '%" + txtKeyword.Text + "%'";
        }

        DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResultNews");

        grdViwNews.DataSource = DS;
        grdViwNews.DataBind();
        grdViwNews.Visible = true;
    }

    protected void btnSearchDye_Click(object sender, EventArgs e)
    {
        grdViwConsult.Visible = false;
        grdViwDye.Visible = false;
        grdViwFertilizer.Visible = false;
        grdViwNews.Visible = false;
        grdViwUsers.Visible = false;

        if (radBtnSearchDyeID.Checked)
        {
            strSqlCmd = "select * from dye where dyeID = '" + txtKeyword.Text + "'";
        }
        else if (radBtnSearchDyeName.Checked)
        {
            strSqlCmd = "select * from dye where dyeName like '%" + txtKeyword.Text + "%'";
        }
        else
        {
            strSqlCmd = "select * from dye where dyeColor like '%" + txtKeyword.Text + "%'";
        }

        DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResultDye");
        grdViwDye.DataSource = DS;
        grdViwDye.DataBind();
        grdViwDye.Visible = true;
        
    }
    protected void btnSearchFertilizer_Click(object sender, EventArgs e)
    {
        grdViwConsult.Visible = false;
        grdViwDye.Visible = false;
        grdViwFertilizer.Visible = false;
        grdViwNews.Visible = false;
        grdViwUsers.Visible = false;

        if (radBtnSearchFertilizerID.Checked)
        {
            strSqlCmd = "select * from fertilizer where fertilizerID = '" + txtKeyword.Text + "'";
        }
        else 
        {
            strSqlCmd = "select * from fertilizer where fertilizerName like '%" + txtKeyword.Text + "%'";
        }
        DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResultFertilizer");
        for (int i = 0; i < DS.Tables["fertilizer"].Rows.Count; i++)
        {
            if (DS.Tables["fertilizer"].Rows[i][2].ToString().Equals("0"))
            {
                DS.Tables["fertilizer"].Rows[i][2] = (string)"否";
            }
            else
            {
                DS.Tables["fertilizer"].Rows[i][2] = (string)"是";
            }

            if (DS.Tables["fertilizer"].Rows[i][3].ToString().Equals("0"))
            {
                DS.Tables["fertilizer"].Rows[i][3] = (string)"否";
            }
            else
            {
                DS.Tables["fertilizer"].Rows[i][3] = (string)"是";
            }

            if (DS.Tables["fertilizer"].Rows[i][4].ToString().Equals("0"))
            {
                DS.Tables["fertilizer"].Rows[i][4] = (string)"否";
            }
            else
            {
                DS.Tables["fertilizer"].Rows[i][4] = (string)"是";
            }
        }


        grdViwFertilizer.DataSource = DS;
        grdViwFertilizer.DataBind();
        grdViwFertilizer.Visible = true;
    }
    protected void btnSearchConsult_Click(object sender, EventArgs e)
    {
        grdViwConsult.Visible = false;
        grdViwDye.Visible = false;
        grdViwFertilizer.Visible = false;
        grdViwNews.Visible = false;
        grdViwUsers.Visible = false;

        if (radBtnSearchConsultID.Checked)
        {
            strSqlCmd = "select * from consult where consultID = '" + txtKeyword.Text + "'";
        }
        else if (radBtnSearchConsultTitle.Checked)
        {
            strSqlCmd = "select * from consult where consultTitle like '%" + txtKeyword.Text + "%'";
        }
        else if(radBtnSearchConsultConcent.Checked)
        {
            strSqlCmd = "select * from consult where consultContent like '%" + txtKeyword.Text + "%'";
        }
        else if (radBtnSearchConsultAnswer.Checked)
        {
            strSqlCmd = "select * from consult where consultAnswer like '%" + txtKeyword.Text + "%'";
        }
        else
        {
            strSqlCmd = "select * from consult where userID = '" + txtKeyword.Text + "'";
        }

        DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResultConsult");

        grdViwConsult.DataSource = DS;
        grdViwConsult.DataBind();
        grdViwConsult.Visible = true;
    }


    protected void btnUserRightModify_Click(object sender, EventArgs e)
    {
        Button btnUserRightModify = (Button)sender;
        string strUserID = btnUserRightModify.CommandName.ToString();
        string strUserRight = btnUserRightModify.CommandArgument.ToString();

        if (strUserRight.Equals("用户"))
        {
            strSqlCmd = "update users set userRight = '1' where userID = '" + strUserID + "'";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");
            Page_Load(sender, e);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('此用户已为管理员')</script>");
        }
    }

    protected void btnUserDelete_Click(object sender, EventArgs e)
    {
        Button btnUserID = (Button)sender;
        string strSqlCmdDelete = "delete from users where userID = '" + btnUserID.CommandArgument.ToString() + "'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);

        Page_Load(sender, e);
    }

    protected void btnManagementNews_Click(object sender, EventArgs e)
    {
        Button btnNewsID = (Button)sender;
        Session["newsID"] = btnNewsID.CommandArgument.ToString();
        Response.Write("<script language=\"javascript\">window.location.href='management_News.aspx'</script>");
    }
    protected void btnManagementFertilizer_Click(object sender, EventArgs e)
    {
        Button btnFertilizerID = (Button)sender;
        Session["fertilizerID"] = btnFertilizerID.CommandArgument.ToString();
        Response.Write("<script language=\"javascript\">window.location.href='management_InforFertilizer.aspx'</script>");
    }
    protected void btnManagementDye_Click(object sender, EventArgs e)
    {
        Button btnDyeID = (Button)sender;
        Session["dyeID"] = btnDyeID.CommandArgument.ToString();
        Response.Write("<script language=\"javascript\">window.location.href='management_InforDye.aspx'</script>");
    }
    protected void btnManagementConsult_Click(object sender, EventArgs e)
    {
        Button btnConsultID = (Button)sender;
        Session["consultID"] = btnConsultID.CommandArgument.ToString();
        Response.Write("<script language=\"javascript\">window.location.href='management_Consult.aspx'</script>");
    }
}
