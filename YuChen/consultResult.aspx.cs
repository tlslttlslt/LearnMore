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

public partial class consultResult : System.Web.UI.Page
{
    string strSqlCmd;
    string strConsultID;
    SqlDataReader sqlDR;

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

            strSqlCmd = "select * from consult where userID = '" + Session["userID"].ToString() + "'";
            string strTblName = "consultResult";

            DataSet DS = DatabaseOperating.fillDataSet(strSqlCmd, strTblName);

            for (int i = 0; i < DS.Tables["consultResult"].Rows.Count; i++)
            {
                if (DS.Tables["consultResult"].Rows[i][2].ToString() == "0")
                {
                    DS.Tables["consultResult"].Rows[i][2] = (string)"公开";
                }
                else
                {
                    DS.Tables["consultResult"].Rows[i][2] = (string)"私有";
                }

            }

            for (int i = 0; i < DS.Tables["consultResult"].Rows.Count; i++)
            {
                if (DS.Tables["consultResult"].Rows[i][7].ToString() == "0")
                {
                    DS.Tables["consultResult"].Rows[i][7] = (string)"未回答";
                }
                else
                {
                    DS.Tables["consultResult"].Rows[i][7] = (string)"已回答";
                }

            }

            grdViwConsultResult.DataSource = DS;

            grdViwConsultResult.DataBind();


        }


    }


    protected void btnConsultView_Click(object sender, EventArgs e)
    {
        Button btnConsultView = (Button)sender;
        strConsultID = btnConsultView.CommandArgument.ToString();
        strSqlCmd = "select * from consult where consultID = '" + strConsultID + "'";

        sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);


        lblConsultTitle.Text = sqlDR["consultTitle"].ToString();
        lblConsultID.Text = btnConsultView.CommandArgument.ToString();
        lblConsultDate.Text = sqlDR["consultDate"].ToString();
        txtConsultContent.Text = sqlDR["consultContent"].ToString();
        txtConsultAnswer.Text = sqlDR["consultAnswer"].ToString();
    }

}
