using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;


public partial class MasterPage : System.Web.UI.MasterPage
{

    public MasterPage()
    {

    }


    public Panel pnlLoginState
    {
        get
        {
            return pnlLogin;
        }
    }

    public Panel pnlLoginDoneState
    {
        get
        {
            return pnlLoginDone;
        }
    }

    public Label lblUserNameState
    {
        get
        {
            return lblUserName;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        btnLogoff.Attributes.Add("onclick", "return confirm('你要执行这个操作吗？')");
    }

    protected void lnkBtnLogin_Click(object sender, EventArgs e)
    {
        lblErrorMessage.Text = "";
        if (txtUserName.Text.ToString().Equals("") || txtUserPassword.Text.ToString().Equals(""))
        {
            lblErrorMessage.Text = "用户名及密码不能为空。";


        }
        else
        {
            try
            {
                string strSqlCmd = "select * from users where userName = '" + txtUserName.Text.ToString() + "'and userPassword = '" + txtUserPassword.Text.ToString() + "'";
                SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);       
                
                if(sqlDR!=null)
                {
                        Session["userName"] = txtUserName.Text;
                        Session["userRight"] = sqlDR["userRight"].ToString();
                        if (sqlDR["userRight"].ToString().Equals("0"))
                        {

                            Response.Redirect("Login_Register_Done.aspx");
                        }

                        else
                        {
                            Response.Redirect("management.aspx");
                        }
                }

                else
                {
                    lblErrorMessage.Text = "登录失败，请确认用户名和密码正确。";

                }
                

            }
            catch
            {  }
        }
    }

    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
}
