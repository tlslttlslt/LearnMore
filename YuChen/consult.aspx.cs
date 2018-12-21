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



public partial class consult : System.Web.UI.Page
{
    string strSqlCmd;
    SqlCommand sqlCmd;
    SqlConnection sqlCnn;



    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userRight"] != null)
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }
                
        if(!Page.IsPostBack)
        {
            if (Session["userID"] == null)
            {
                Response.Write(" <script   language='javascript'> alert('对不起,你无此权限。请返回首页登录。')</script> ");
                Response.Write("<script language=\"javascript\">window.location.href='Default.aspx'</script>");

            }


            if (Session["consultSort"] != null && Session["consultAbout"] != null)
            {
                if (Session["consultSort"].ToString().Equals("fertilizer"))
                {
                    radBtnConsultSortFertilizer.Checked = true;

                }
                else
                {
                    radBtnConsultSortDye.Checked = true;
                }

                txtConsultTitle.Text = "关于商品 " + Session["consultAbout"].ToString() + " 的提问";

            }

        }


       
    }


    protected void btnConsultSubmit_Click(object sender, EventArgs e)
    {
        
        string strConsultSort ;
        string strConsultPrivate ;


        if(radBtnConsultSortDye.Checked)
        {
            strConsultSort = "染料";
        }
        else
        {
            strConsultSort = "肥料";
        }

        if (radBtnConsultPrivate0.Checked)
        {
            strConsultPrivate = "0";
        }
        else
        {
            strConsultPrivate = "1";
        }

        sqlCnn = DatabaseOperating.creatDBConnect();
        strSqlCmd = "insert into consult(consultTitle,consultSort,consultPrivate,consultDate,consultContent,consultAnswered,userID) values('"
                    + txtConsultTitle.Text + "','"
                    + strConsultSort +"','"
                    + strConsultPrivate +"','"
                    + DateTime.Today.ToShortDateString().ToString() +"','"
                    + txtConsultContent.Text +"','"
                    + "0" +"','"
                    + Session["userID"].ToString() + "')";


        sqlCmd = new SqlCommand(strSqlCmd, sqlCnn);
        sqlCmd.ExecuteNonQuery();
        Response.Write("<script language=javascript>alert('提问成功！')</script>");
        sqlCnn.Close();

    }
}
