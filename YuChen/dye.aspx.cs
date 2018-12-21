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



public partial class dye : System.Web.UI.Page
{
    string strSqlCmd;
    string strTblName;

    DataSet DS;

    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["userName"] == null)
        {

            this.Master.pnlLoginDoneState.Visible = false;
            this.Master.pnlLoginState.Visible = true;
        }
        else
        {
            this.Master.lblUserNameState.Text = Session["userName"].ToString();

            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
        }
        
        
        strSqlCmd = "select * from dye ";
        strTblName = "dye";

        DS = DatabaseOperating.fillDataSet(strSqlCmd, strTblName);

        grdViwDye.DataSource = DS;
        grdViwDye.DataBind();
    }
    protected void btnDyeConsult_Click(object sender, EventArgs e)
    {

        Button btnDyeName = (Button)sender;
        Session["consultSort"] = "Dye";
        Session["consultAbout"] = btnDyeName.CommandArgument.ToString();
        Response.Redirect("consult.aspx");

    }

}
