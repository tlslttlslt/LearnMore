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

public partial class modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userRight"] == null)
        {

            Response.Write(" <script   language=\"javascript\"> alert(\"对不起,你无此权限。请返回首页登录。\");window.location.href='Default.aspx'</script> ");

        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
            lblUserName.Text = Session["userName"].ToString();
        }
    }


    SqlConnection sqlCnn;

    protected void btnModify_Click(object sender, EventArgs e)
    {
        sqlCnn = DatabaseOperating.creatDBConnect();
        string strResult;
        
        
        if (txtUserOldPassword.Text.ToString().Equals(""))
        {
            lblErrorMessage.Text = "请输入旧密码。";

        }

        else
        {
            try
            {
                string strSqlCmdLoginCheck = "select count(*) from users where userName = '" + lblUserName.Text.ToString() + "'and userPassword = '" + txtUserOldPassword.Text.ToString() + "'";
                SqlCommand sqlCmd = new SqlCommand(strSqlCmdLoginCheck, sqlCnn);

                strResult = sqlCmd.ExecuteScalar().ToString();

                if (strResult.Equals("1"))
                {
                    if(txtUserNewPassword.Text.Equals("")||txtUserNewPasswordConfig.Text.Equals(""))
                    {
                        lblErrorMessage.Text = "新密码和新密码确认不能为空。";
                    }

                    else if (!txtUserNewPassword.Text.Equals(txtUserNewPasswordConfig.Text))
                    {
                        lblErrorMessage.Text = "两次输入的新密码不一致。";

                    }

                    else
                    {
                        string strSqlCmd = "update users set userPassword = '" + txtUserNewPassword.Text + " ' ,userZone = '" + DrpDwnLstZone.SelectedItem.Text + " ' where userName = '" + lblUserName.Text + "'";
                        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
                        Response.Write("<script language=javascript>alert('恭喜您，修改成功！')</script>");
                        Response.Write("<script language=javascript>window.location.href='Login_Register_Done.aspx'</script>");

                    }
                }
                else
                {
                    lblErrorMessage.Text = "旧密码错误，请重新输入。";

                }

            }
            catch
            {}
        }
        
        
       

    }
    protected void btnReset_Click(object sender, EventArgs e)
    {

        DrpDwnLstZone.SelectedValue = "东北";
        txtUserNewPassword.Text = "";
        txtUserNewPasswordConfig.Text = "";
        txtUserOldPassword.Text = "";
    }
}
