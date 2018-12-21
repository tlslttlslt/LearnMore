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
    string strTblName;
    DataSet DS;
    string strConsultID;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["userRight"] == null || !Session["userRight"].ToString().Equals("1"))
        {
            Response.Write(" <script language=\"javascript\"> alert(\"对不起,你无此权限。请返回首页登录。\");window.location.href='Default.aspx'</script> ");

        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }


        if (Session["consultID"] != null)
        {
            strSqlCmd = "select * from consult where consultID = '" + Session["consultID"].ToString() + "'";
            SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);

            lblConsultTitle.Text = sqlDR["consultTitle"].ToString();
            lblConsultID.Text = Session["consultID"].ToString();
            lblConsultDate.Text = sqlDR["consultDate"].ToString();
            txtConsultContent.Text = sqlDR["consultContent"].ToString();
            txtConsultAnswer.Enabled = true;
            sqlDR.Close();

        }

        strSqlCmd = "select * from consult";
        strTblName = "consult";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, strTblName);


        for (int i = 0; i < DS.Tables["consult"].Rows.Count; i++)
        {
            if (DS.Tables["consult"].Rows[i][2].ToString().Equals("0"))
            {
                DS.Tables["consult"].Rows[i][2] = (string)"公开";
            }
            else
            {
                DS.Tables["consult"].Rows[i][2] = (string)"私有";
            }

            if (DS.Tables["consult"].Rows[i][7].ToString().Equals("1"))//Rows[i][7]是“7”还是别的什么要看原始数据表里是第几列
            {
                DS.Tables["consult"].Rows[i][7] = (string)"已回答";
            }
            else
            {
                DS.Tables["consult"].Rows[i][7] = (string)"未回答";
            }
        }

        grdViwConsult.DataSource = DS;
        grdViwConsult.DataBind();

    }
    protected void btnConsultAnswer_Click(object sender, EventArgs e)
    {
        Button btnConsultAnswer = (Button)sender;
        strConsultID = btnConsultAnswer.CommandArgument.ToString();
        strSqlCmd = "select * from consult where consultID = '" + strConsultID +"'";
        SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);

        lblConsultTitle.Text = sqlDR["consultTitle"].ToString();
        lblConsultID.Text = btnConsultAnswer.CommandArgument.ToString();
        lblConsultDate.Text = sqlDR["consultDate"].ToString();
        txtConsultContent.Text = sqlDR["consultContent"].ToString();
        txtConsultAnswer.Enabled = true;

    }
    protected void btnConsultAnswerSubmit_Click(object sender, EventArgs e)
    {
        strSqlCmd = "update consult set consultAnswer = '"+ txtConsultAnswer.Text +"',consultAnswered = '1' where consultID = '"+ lblConsultID.Text +"'";

        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);

        Response.Write("<script>alert('回答成功')</script>");

        Page_Load(sender,e);

    }
    protected void btnConsultDelete_Click(object sender, EventArgs e)
    {
        Button btnConsultID = (Button)sender;

        string strSqlCmd = "delete from consult where consultID = '" + btnConsultID.CommandArgument.ToString() + "'";

        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Response.Write("<script>alert('删除成功')</script>");

        Page_Load(sender, e);
    }

}
