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

public partial class searchResult : System.Web.UI.Page
{
    string strSqlCmd;
    SqlDataReader sqlDR;
    DataSet DS;

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
        }


        if (Session["keyword"] != null)
        {
            lblSearchNoResult.Visible = false;

            if (Session["inforSort"].ToString().Equals("infor"))
            {
                if (Session["goodsSort"].ToString().Equals("dye"))
                {
                    strSqlCmd = "select * from dye where dyeName like '%" + Session["keyword"].ToString() + "%'";
                    DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResult");

                    if (DS.Tables["searchResult"].Rows.Count>0)
                    {
                        grdViwDye.DataSource = DS;
                        grdViwDye.DataBind();

                        grdViwDye.Visible = true;
                    }
                    else
                    {
                        lblSearchNoResult.Visible = true;
                        lblSearchNoResult.Text = "对不起，没有任何记录。";
                    }
                }
                else
                {
                    strSqlCmd = "select * from fertilizer where fertilizerName like '%" + Session["keyword"].ToString() + "%'";
                    DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResult");

                    if (DS.Tables["searchResult"].Rows.Count > 0)
                    {
                        grdViwDye.DataSource = DS;
                        grdViwDye.DataBind();

                        grdViwDye.Visible = true;
                    }
                    else
                    {
                        lblSearchNoResult.Visible = true;
                        lblSearchNoResult.Text = "对不起，没有任何记录。";
                    }
                }

            }
            else
            {
                if (Session["goodsSort"].ToString().Equals("dye"))
                {
                    strSqlCmd = "select * from consult where consultSort = '染料' and consultPrivate = '0' and consultContent like '%" + Session["keyword"].ToString() + "%'or consultTitle like '%" + Session["keyword"].ToString() + "%'or consultAnswer like '%" + Session["keyword"].ToString() + "%'";
                    DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResult");

                    if (DS.Tables["searchResult"].Rows.Count > 0)
                    {
                        grdViwDye.DataSource = DS;
                        grdViwDye.DataBind();

                        grdViwDye.Visible = true;
                    }
                    else
                    {
                        lblSearchNoResult.Visible = true;
                        lblSearchNoResult.Text = "对不起，没有任何记录。";
                    }
                }
                else
                {

                    strSqlCmd = "select * from consult where consultSort = '肥料' and consultPrivate = '0' and consultContent like '%" + Session["keyword"].ToString() + "%'or consultTitle like '%" + Session["keyword"].ToString() + "%'or consultAnswer like '%" + Session["keyword"].ToString() + "%'";
                    DS = DatabaseOperating.fillDataSet(strSqlCmd, "searchResult");


                    if (DS.Tables["searchResult"].Rows.Count > 0)
                    {
                        grdViwDye.DataSource = DS;
                        grdViwDye.DataBind();

                        grdViwDye.Visible = true;
                    }
                    else
                    {
                        lblSearchNoResult.Visible = true;
                        lblSearchNoResult.Text = "对不起，没有任何记录。";
                    }
                }
            }
        }


    }

    protected void btnConsultFertilizer_Click(object sender, EventArgs e)
    {

        Button btnFertilizerName = (Button)sender;
        Session["consultSort"] = "fertilizer";
        Session["consultAbout"] = btnFertilizerName.CommandArgument.ToString();
        Response.Redirect("consult.aspx");
    }
    protected void btnConsultDye_Click(object sender, EventArgs e)
    {
        Button btnDyeName = (Button)sender;
        Session["consultSort"] = "dye";
        Session["consultAbout"] = btnDyeName.CommandArgument.ToString();
        Response.Redirect("consult.aspx");
    }
    protected void btnConsultView_Click(object sender, EventArgs e)
    {
        Button btnConsultID = (Button)sender;
        strSqlCmd = "select * from consult where consultID = '"+btnConsultID.CommandArgument.ToString()+"'";
        sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);

        pnlConsultView.Visible = true;
        lblConsultTitle.Text = sqlDR["consultTitle"].ToString();
        lblConsultSort.Text = sqlDR["consultSort"].ToString();
        lblConsultDate.Text = sqlDR["consultDate"].ToString();
        txtConsultContent.Text = sqlDR["consultContent"].ToString();
        txtConsultAnswer.Text = sqlDR["consultAnswer"].ToString();

    }

}
