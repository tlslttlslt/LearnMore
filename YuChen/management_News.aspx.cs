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

public partial class management_Member : System.Web.UI.Page
{

    string strSqlCmd;
    DataSet DS;

    SqlDataReader sqlDR;

    string strNewsID;
    
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


        if (Session["newsID"] != null)
        {

            txtNewsTitle.ReadOnly = false;
            txtNewsContent.ReadOnly = false;
            btnNewsModifyAddSubmit.Text = "修改";
            strSqlCmd = "select * from news where newsID = '" + Session["newsID"].ToString() + "'";
            sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);

            txtNewsTitle.Text = sqlDR["newsTitle"].ToString();
            lblNewsID.Text = Session["newsID"].ToString();
            lblNewsDate.Text = sqlDR["newsDate"].ToString();
            txtNewsContent.Text = sqlDR["newsContent"].ToString();
            sqlDR.Close();
        
        }

        strSqlCmd = "select * from news";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, "news");

        grdViwNews.DataSource = DS;

        grdViwNews.DataBind();

    }
    protected void btnNewsModify_Click(object sender, EventArgs e)
    {

        txtNewsTitle.ReadOnly = false;
        txtNewsContent.ReadOnly = false;
        btnNewsModifyAddSubmit.Text = "修改";
        Button btnNewsAnswer = (Button)sender;
        strNewsID = btnNewsAnswer.CommandArgument.ToString();
        strSqlCmd = "select * from news where newsID = '" + strNewsID +"'";

        sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);


        txtNewsTitle.Text = sqlDR["newsTitle"].ToString();
        lblNewsID.Text = btnNewsAnswer.CommandArgument.ToString();
        lblNewsDate.Text = sqlDR["newsDate"].ToString();
        txtNewsContent.Text = sqlDR["newsContent"].ToString();

    }



    protected void btnNewsDelete_Click(object sender, EventArgs e)
    {
        Button btnNewsID = (Button)sender;

        string strSqlCmd = "delete from news where newsID = '" + btnNewsID.CommandArgument.ToString() + "'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Page_Load(sender, e);
    }


    protected void btnNewsAdd_Click(object sender, EventArgs e)
    {
        txtNewsTitle.ReadOnly = false;
        txtNewsContent.ReadOnly = false;
        txtNewsTitle.Enabled = true;
        txtNewsTitle.Text = "";
        txtNewsContent.Text = "";
        btnNewsModifyAddSubmit.Text = "添加";
        lblNewsID.Text = "此项自动添加";
        lblNewsDate.Text = "此项自动添加";
    }
    protected void btnNewsModifyAddSubmit_Click(object sender, EventArgs e)
    {
        if(btnNewsModifyAddSubmit.Text.Equals("添加"))
        {
            strSqlCmd = "insert into news(newsTitle,newsDate,newsContent) values('" + txtNewsTitle.Text + "','"
                        + DateTime.Today.ToShortDateString().ToString() + "','"
                        + txtNewsContent.Text + "')";

            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            Response.Write("<script>alert('添加成功')</script>");
        }
        else
        {
            strSqlCmd = "update news set newsTitle = '"+ txtNewsTitle.Text +"',newsContent = '" +txtNewsContent.Text+ "' where newsID = '"+ lblNewsID.Text +"'";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            Response.Write("<script>alert('编辑成功')</script>");
        }
        Page_Load(sender, e);

    }
}
