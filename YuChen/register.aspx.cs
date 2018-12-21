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


using System.Text.RegularExpressions; 

public partial class register : System.Web.UI.Page
{
    string strSqlCmd;
    SqlCommand sqlCmd;
    SqlDataReader sqlDR;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userRight"] == null)
        {
            this.Master.pnlLoginDoneState.Visible = false;
            this.Master.pnlLoginState.Visible = true;

        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        txtUserName.Text = "";
        txtUserPassword.Text = "";
        txtUserPasswordConfig.Text = "";
        DrpDwnLstZone.SelectedValue = "东北";
        txtUserEmail.Text = "";
    }



    protected void btnRegister_Click(object sender, EventArgs e)
    {
        SqlConnection sqlCnn = DatabaseOperating.creatDBConnect();
        
        Regex regUserName = new Regex(@"^\w+$");                                                // 只能输入由数字、26个英文字母或者下划线组成的字符串
        Regex regUserpassword = new Regex(@"^[a-zA-Z]\w{5,17}$");                               // 以字母开头，长度在6~18之间，只能包含字符、数字和下划线
        Regex regMail = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");              // 验证Email地址格式

        strSqlCmd = "select count(*) from users where userName = '" + txtUserName.Text.ToString() + "'";        // 验证是否已存在此用户
        sqlCmd = new SqlCommand(strSqlCmd, sqlCnn);
        string strResultUserNameCheck = sqlCmd.ExecuteScalar().ToString();


        strSqlCmd = "select count(*) from users where userEmail = '" + txtUserEmail.Text.ToString() + "'";     // 验证是否已有用户使用此邮箱
        sqlCmd = new SqlCommand(strSqlCmd, sqlCnn);
        string strResultUserEmailCheck = sqlCmd.ExecuteScalar().ToString();


        #region 验证注册信息
        if (txtUserName.Text.Equals(""))
        {
            lblErrorMessage.Text = "用户名不能为空。";
        }


        else if (!regUserName.IsMatch(txtUserName.Text.ToString()))
        {
            lblErrorMessage.Text = "用户名格式不正确。只能输入由数字、26个英文字母或者下划线组成的字符串";

        }
        else if (strResultUserNameCheck == "1")
        {
            lblErrorMessage.Text = "此用户名已被注册，请您另择其他。";
        }


        else if (txtUserPassword.Text.Equals(""))
        {
            lblErrorMessage.Text = "密码不能为空。";
        
        }
        else if(!regUserpassword.IsMatch(txtUserPassword.Text.ToString()))
        {
            lblErrorMessage.Text = "密码格式不正确。只能以字母开头，长度在6~18之间，只能包含字符、数字和下划线";
  
        }
        else if (txtUserPasswordConfig.Text.Equals(""))
        {
            lblErrorMessage.Text = "密码确认不能为空。";

        }

        else if (!txtUserPassword.Text.ToString().Equals(txtUserPasswordConfig.Text.ToString()))
        {
            lblErrorMessage.Text = "两次输入的密码不一致，请重新输入。";

        }

        else if (txtUserEmail.Text.Equals(""))
        {
            lblErrorMessage.Text = "邮件地址不能为空。";

        }

        else if (!regMail.IsMatch(txtUserEmail.Text.ToString()))
        {
            lblErrorMessage.Text = "邮件格式不正确。";
        }


        else if (strResultUserEmailCheck == "1")
        {
            lblErrorMessage.Text = "此邮箱已被注册，请您另择其他。";
        }

        #endregion

        #region 添加新用户


        else
        {

            strSqlCmd = "insert into users(userName, userPassword, userZone, userEmail, userRegisterDate, userRight) values( "
                                            + "'" + txtUserName.Text.ToString() + "'"
                                            + ","
                                            + "'" + txtUserPassword.Text.ToString() + "'"
                                            + ","
                                            + "'" + DrpDwnLstZone.SelectedItem.Text.ToString() + "'"
                                            + ","
                                            + "'" + txtUserEmail.Text.ToString() + "'"
                                            + ","
                                            + "'" + DateTime.Today.ToShortDateString().ToString() + "'"
                                            + ","
                                            + "'" + "0" + "'"
                                            + ")";

            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);

            string strUserID;
            strSqlCmd = "select userID from users where userName = '" + txtUserName.Text.ToString() + "'";
            sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);
            strUserID = sqlDR["userID"].ToString();

            Session["userName"] = txtUserName.Text;
            Session["userRight"] = "0";
            Session["userID"]= strUserID;
            Response.Write(" <script   language=\"javascript\"> alert(\"注册成功\");window.location.href='Login_Register_Done.aspx'</script> ");


        }

        #endregion

        sqlCnn.Close();

    }

}
