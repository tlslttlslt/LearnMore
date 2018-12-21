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

        //btnUserAdd.Attributes.Add("onclick", "return confirm('确定添加用户吗？')");


        strSqlCmd = "select * from users";

        DataSet DSUsers = DatabaseOperating.fillDataSet(strSqlCmd, "users");



        for (int i = 0; i < DSUsers.Tables["users"].Rows.Count; i++)
        {
            if (DSUsers.Tables["users"].Rows[i][6].ToString().Equals("0"))
            {
                DSUsers.Tables["users"].Rows[i][6] = (string)"用户";
            }
            else
            {
                DSUsers.Tables["users"].Rows[i][6] = (string)"管理员";
            }

        }

        grdViwUsers.DataSource = DSUsers;

        grdViwUsers.DataBind();




    }

    protected void btnUserRightModify_Click(object sender, EventArgs e)
    {
        Button btnUserRightModify = (Button)sender;
        string strUserID =  btnUserRightModify.CommandName.ToString();
        string strUserRight = btnUserRightModify.CommandArgument.ToString();

        if (strUserRight.Equals("用户"))
        {
            strSqlCmd = "update users set userRight = '1' where userID = '"  + strUserID +  "'" ;
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            Response.Write("<script language='javascript'>alert('修改成功！')</script>");
            Page_Load(sender, e);
        }
        else
        {
            Response.Write("<script language='javascript'>alert('此用户已为管理员')</script>");
        }
    }
    protected void btnPnlUserAddDisplay_Click(object sender, EventArgs e)
    {
        Button btnPnlUserAddDisplay = (Button)sender;

        if (btnPnlUserAddDisplay.Text.ToString().Equals("添加用户"))
        {
            pnlUserAdd.Visible = true;
            btnPnlUserAddDisplay.Text = "取消添加";

        }

        else 
        {
            pnlUserAdd.Visible = false;

            btnPnlUserAddDisplay.Text = "添加用户";

        
        }
    }
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Page_Load(sender,e);


    }



    protected void btnUserDelete_Click(object sender, EventArgs e)
    {
        Button btnUserID = (Button) sender;
        string strSqlCmd = "delete from users where userID = '" + btnUserID.CommandArgument.ToString() +"'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Page_Load(sender, e);
    }



    protected void btnUserAdd_Click(object sender, EventArgs e)
    {
        strSqlCmd = "insert into users(userName, userPassword, userZone, userEmail, userRegisterDate, userRight) values( "
                                        + "'" + txtUserName.Text.ToString() + "'"
                                        + ","
                                        + "'" + txtUserPassword.Text.ToString() + "'"
                                        + ","
                                        + "'" + DrpDwnLstUserZone.SelectedValue.ToString() + "'"
                                        + ","
                                        + "'" + txtUserEmail.Text.ToString() + "'"
                                        + ","
                                        + "'" + DateTime.Today.ToShortDateString().ToString() + "'"
                                        + ","
                                        + "'" + drpDwnLstUserRight.SelectedValue.ToString() + "'"
                                        + ")";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Response.Write(" <script language=\"javascript\"> alert(\"注册成功\")</script> ");

    }
}
