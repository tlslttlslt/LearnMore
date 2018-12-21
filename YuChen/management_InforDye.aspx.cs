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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userRight"] == null || !Session["userRight"].ToString().Equals("1"))
        {

            Response.Write(" <script   language=\"javascript\"> alert(\"对不起,你无此权限。请返回首页登录。\");window.location.href='Default.aspx'</script> ");
        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }

        if (Session["dyeID"] != null)
        {
            btnDyeAddModify.Text = "修改";

            strSqlCmd = "select * from dye where dyeID = '" + Session["dyeID"].ToString() + "'";

            SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);


            lblDyeID.Text = Session["dyeID"].ToString();
            txtDyeName.Text = sqlDR["dyeName"].ToString();

            txtDyeColor.Text = sqlDR["dyeColor"].ToString();

            txtDyeStock.Text = sqlDR["dyeStock"].ToString();
            sqlDR.Close();

        }

        strSqlCmd = "select * from dye";
        strTblName = "dye";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, strTblName);




        grdViwDye.DataSource = DS;

        grdViwDye.DataBind();




    }

    protected void btnDyeModify_Click(object sender, EventArgs e)
    {
        btnDyeAddModify.Text = "修改";
        Button btnDyeModify = (Button)sender;
        string strDyeID = btnDyeModify.CommandArgument.ToString();

        strSqlCmd = "select * from dye where dyeID = '" + strDyeID + "'";

        SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);

        lblDyeID.Text = strDyeID;
        txtDyeName.Text = sqlDR["dyeName"].ToString();

        txtDyeColor.Text = sqlDR["dyeColor"].ToString();

        txtDyeStock.Text = sqlDR["dyeStock"].ToString();
    


    }




    protected void btnDyeDelete_Click(object sender, EventArgs e)
    {
        Button btnDyeID = (Button) sender;

        string strSqlCmd = "delete from dye where dyeID = '" + btnDyeID.CommandArgument.ToString() + "'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Page_Load(sender, e);
    }





    protected void btnDyeAddModify_Click(object sender, EventArgs e)
    {
        
        
        if (btnDyeAddModify.Text.Equals("修改"))
        {
            strSqlCmd = "update dye set dyeName = '" + txtDyeName.Text
                                      
                                    + "',dyeColor = '" + txtDyeColor.Text
                                    + "',dyeStock = '" + txtDyeStock.Text + "' where dyeID = '" + lblDyeID.Text + "'";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        }


        else if (btnDyeAddModify.Text.Equals("添加"))
        {
            strSqlCmd = "insert into dye(dyeName,dyeColor,dyeStock) values('"
            + txtDyeName.Text + "','"
            + txtDyeColor.Text + "','"
            
            + txtDyeStock.Text + "')";

            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        
        }

        Page_Load(sender, e);

        txtDyeName.Text = "";
        txtDyeColor.Text = "";
        txtDyeStock.Text = "";
    }
    protected void btnDyeAdd_Click(object sender, EventArgs e)
    {
        btnDyeAddModify.Text = "添加";
        lblDyeID.Text = "此项自动添加";
        txtDyeName.Text = "";




        txtDyeColor.Text = "";

        txtDyeStock.Text = "";
    
    }
}
