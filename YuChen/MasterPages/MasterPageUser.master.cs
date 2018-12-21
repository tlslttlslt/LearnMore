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



    string strSqlCmd;
    DataSet DS;
    SqlDataReader sqlDR;

    public MasterPage()
    {

    }

    #region 定义三个公共属性以访问私有变量
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
    #endregion

    
    protected void Page_Load(object sender, EventArgs e)
    {

        btnLogoff.Attributes.Add("onclick","return confirm('你要执行这个操作吗？')");


        #region 取得links表中的数据
        try
        {
            strSqlCmd = "select * from links";                                              // 查询语字符串
            DS = DatabaseOperating.fillDataSet(strSqlCmd, "links");

            grdViwLinks.DataSource = DS;
            grdViwLinks.DataBind();

        }
        catch(Exception excpLinksError)
        {
            lblErrorMessage.Text = excpLinksError.Message.ToString();
        }        
        #endregion

        #region 取得news表中的数据
        try 
        {
            strSqlCmd = "select * from news";
            DS = DatabaseOperating.fillDataSet(strSqlCmd, "news");
            grdViwNews.DataSource = DS;
            grdViwNews.DataBind();

        }

        catch (Exception excpNewsError)
        {
            lblErrorMessage.Text = excpNewsError.Message.ToString();
            lblErrorMessage.Text = "";
        }

        #endregion

    
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
                sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);
                
                if(sqlDR!=null)
                {
                    Session["userName"] = txtUserName.Text;
                    Session["userRight"] = sqlDR["userRight"].ToString();
                    Session["userID"] = sqlDR["userID"].ToString();
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
            {}
        }
    }




    protected void lnkBtnNewsTitle_Click(object sender, EventArgs e)
    {
        LinkButton lnkBtnNewsTitle = (LinkButton)sender;
        string strNewsTitle = lnkBtnNewsTitle.Text;

       
        strSqlCmd = "select * from news where newsTitle = '" + strNewsTitle + "'";
        sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);


        lblNewsTitle.Text = strNewsTitle;   
        lblNewsDate.Text = sqlDR["newsDate"].ToString();

        txtNewsContent.Text = sqlDR["newsContent"].ToString();


    }
    protected void lnkBtnLinks_Click(object sender, EventArgs e)
    {
        LinkButton lnkBtnLinks = (LinkButton)sender;
        Response.Redirect(lnkBtnLinks.CommandArgument.ToString());//网址前要加http:// 否则否则为本地地址
        //Server.Transfer(lnkBtnLinks.CommandArgument.ToString());
        //Response.Write("<script>window.open('" + lnkBtnLinks.CommandArgument.ToString()+"')</script>");

        //Response.Write("<script>window.location.href='http://" + lnkBtnLinks.CommandArgument.ToString() + "';</script>");       
    }
    protected void btnSearchSubmit_Click(object sender, EventArgs e)
    {
        Session["keyword"] = txtKeyword.Text;
        Session["goodsSort"] = "";
        Session["inforSort"] = "";
        if (radBtnGoodsDye.Checked)
        {
            Session["goodsSort"] = "dye";
        }
        else 
        {
            Session["goodsSort"] = "fertilizer";
        }
        if (radBtnConsult.Checked)
        {
            Session["inforSort"] = "consult";
        }
        else 
        {
            Session["inforSort"] = "infor";
        }

        Response.Redirect("searchResult.aspx");
    }
    protected void btnLogoff_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }

}
