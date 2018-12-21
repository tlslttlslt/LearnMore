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
    DataSet DS;

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

        if (Session["fertilizerID"] != null)
        {
            btnFertilizerAddModify.Text = "修改";


            strSqlCmd = "select * from fertilizer where fertilizerID = '" + Session["fertilizerID"].ToString() + "'";
            SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);


            lblFertilizerID.Text = Session["fertilizerID"].ToString();
            txtFertilizerName.Text = sqlDR["fertilizerName"].ToString();
            if (sqlDR["fertilizerCompound"].ToString().Equals("0"))
            {
                radBtnFertilizerCompound0.Checked = true;
                radBtnFertilizerCompound1.Checked = false;
            }
            else
            {
                radBtnFertilizerCompound0.Checked = false;
                radBtnFertilizerCompound1.Checked = true;
            }


            if (sqlDR["fertilizerOrganic"].ToString().Equals("0"))
            {
                radBtnFertilizerOrganic0.Checked = true;
                radBtnFertilizerOrganic1.Checked = false;
            }
            else
            {
                radBtnFertilizerOrganic0.Checked = false;
                radBtnFertilizerOrganic1.Checked = true;
            }


            if (sqlDR["fertilizerAfter"].ToString().Equals("0"))
            {
                radBtnFertilizerAfter0.Checked = true;
                radBtnFertilizerAfter1.Checked = false;
            }
            else
            {
                radBtnFertilizerAfter0.Checked = false;
                radBtnFertilizerAfter1.Checked = true;
            }

            txtFertilizerDilute.Text = sqlDR["fertilizerDilute"].ToString();
            txtFertilizerIngredient.Text = sqlDR["fertilizerIngredient"].ToString();
            drpDwnLstFertilizerSoil.SelectedValue = sqlDR["fertilizerSoil"].ToString();
            txtFertilizerFrequency.Text = sqlDR["fertilizerFrequency"].ToString();
            txtFertilizerStock.Text = sqlDR["fertilizerStock"].ToString();

            sqlDR.Close();

        }


        strSqlCmd = "select * from fertilizer";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, "fertilizer");


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

    protected void btnFertilizerModify_Click(object sender, EventArgs e)
    {
        btnFertilizerAddModify.Text = "修改";
        Button btnFertilizerModify = (Button)sender;
        string strFertilizerID = btnFertilizerModify.CommandArgument.ToString();

        strSqlCmd = "select * from fertilizer where fertilizerID = '" + strFertilizerID + "'";
        SqlDataReader sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd );

        lblFertilizerID.Text = strFertilizerID;
        txtFertilizerName.Text = sqlDR["fertilizerName"].ToString();
        if (sqlDR["fertilizerCompound"].ToString().Equals("0"))
        {
            radBtnFertilizerCompound0.Checked = true;
            radBtnFertilizerCompound1.Checked = false;
        }
        else
        {
            radBtnFertilizerCompound0.Checked = false;
            radBtnFertilizerCompound1.Checked = true;
        }


        if (sqlDR["fertilizerOrganic"].ToString().Equals("0"))
        {
            radBtnFertilizerOrganic0.Checked = true;
            radBtnFertilizerOrganic1.Checked = false;
        }
        else
        {
            radBtnFertilizerOrganic0.Checked = false;
            radBtnFertilizerOrganic1.Checked = true;
        }


        if (sqlDR["fertilizerAfter"].ToString().Equals("0"))
        {
            radBtnFertilizerAfter0.Checked = true;
            radBtnFertilizerAfter1.Checked = false;
        }
        else
        {
            radBtnFertilizerAfter0.Checked = false;
            radBtnFertilizerAfter1.Checked = true;
        }

        txtFertilizerDilute.Text = sqlDR["fertilizerDilute"].ToString();
        txtFertilizerIngredient.Text = sqlDR["fertilizerIngredient"].ToString();
        drpDwnLstFertilizerSoil.SelectedValue = sqlDR["fertilizerSoil"].ToString();
        txtFertilizerFrequency.Text = sqlDR["fertilizerFrequency"].ToString();
        txtFertilizerStock.Text = sqlDR["fertilizerStock"].ToString();
    
    }




    protected void btnFertilizerDelete_Click(object sender, EventArgs e)
    {
        Button btnFertilizerID = (Button) sender;

        string strSqlCmdDelete = "delete from fertilizer where fertilizerID = '" + btnFertilizerID.CommandArgument.ToString() + "'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        Page_Load(sender,e);
    }





    protected void btnFertilizerAddModify_Click(object sender, EventArgs e)
    {
        string strFertilizerCompound ;
        string strFertilizerOrganic ;
        string strFertilizerAfter ;

        if(radBtnFertilizerCompound0.Checked)
        {
            strFertilizerCompound = "0";
        }
        else
        {
            strFertilizerCompound = "1";
        }

        if(radBtnFertilizerOrganic0.Checked)
        {
            strFertilizerOrganic = "0";
        }
        else
        {
            strFertilizerOrganic = "1";
        }
        
        if(radBtnFertilizerAfter0.Checked)
        {
            strFertilizerAfter = "0";
        }
        else
        {
            strFertilizerAfter = "1";
        }        
        
        
        if (btnFertilizerAddModify.Text.Equals("修改"))
        {
            strSqlCmd = "update fertilizer set fertilizerName = '" + txtFertilizerName.Text
                                      + "',fertilizerCompound = '" + strFertilizerCompound
                                      + "',fertilizerOrganic = '" + strFertilizerOrganic
                                      + "',fertilizerAfter = '" + strFertilizerAfter
                                      + "',fertilizerDilute = '" + txtFertilizerDilute.Text
                                      + "',fertilizerIngredient = '" + txtFertilizerIngredient.Text
                                    + "',fertilizerSoil = '" + drpDwnLstFertilizerSoil.SelectedValue
                                    + "',fertilizerFrequency = '" + txtFertilizerFrequency.Text
                                    + "',fertilizerStock = '" + txtFertilizerStock.Text + "' where fertilizerID = '" + lblFertilizerID.Text + "'";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);


            grdViwFertilizer.DataSource = DS;

            grdViwFertilizer.DataBind();


            Response.Write("<script language=\"javascript\">alert('修改成功')</script>");

        }


        else if (btnFertilizerAddModify.Text.Equals("添加"))
        {
            strSqlCmd = "insert into fertilizer(fertilizerName,fertilizerCompound,fertilizerOrganic,fertilizerAfter,fertilizerDilute,fertilizerIngredient,fertilizerSoil,fertilizerFrequency,fertilizerStock) values('"
            + txtFertilizerName.Text + "','"
            + strFertilizerCompound + "','"
            + strFertilizerOrganic + "','"
            + strFertilizerAfter + "','"
            + txtFertilizerDilute.Text + "','"
            + txtFertilizerIngredient.Text + "','"
            + drpDwnLstFertilizerSoil.SelectedValue + "','"
            + txtFertilizerFrequency.Text + "','"
            + txtFertilizerStock.Text + "')";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            grdViwFertilizer.DataSource = DS;
            grdViwFertilizer.DataBind();
            Response.Write("<script language=\"javascript\">alert('添加成功')</script>");
        }

        Page_Load(sender,e);
    }
    protected void btnFertilizerAdd_Click(object sender, EventArgs e)
    {
        btnFertilizerAddModify.Text = "添加";
        lblFertilizerID.Text = "此项自动添加";
        txtFertilizerName.Text = "";

        radBtnFertilizerCompound0.Checked = false;
        radBtnFertilizerCompound1.Checked = true;



        radBtnFertilizerOrganic0.Checked = false;
        radBtnFertilizerOrganic1.Checked = true;



        radBtnFertilizerAfter0.Checked = false;
        radBtnFertilizerAfter1.Checked = true;


        txtFertilizerDilute.Text = "";
        txtFertilizerIngredient.Text = "";
        drpDwnLstFertilizerSoil.SelectedValue = "东北黑土地";
        txtFertilizerFrequency.Text = "";
        txtFertilizerStock.Text = "";
    
    }
}
