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




        strSqlCmd = "select * from fertilizer";
        strTblName = "fertilizer";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, strTblName);
        
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




    }
    protected void btnFertilizerConsult_Click(object sender, EventArgs e)
    {
        Button btnFertilizerName = (Button)sender;
        Session["consultSort"] = "fertilizer";
        Session["consultAbout"] = btnFertilizerName.CommandArgument.ToString();
        Response.Redirect("consult.aspx");
    }
}
