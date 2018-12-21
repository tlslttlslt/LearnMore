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



public partial class management_links : System.Web.UI.Page
{
    string strSqlCmd;

    DataSet DS;
    SqlDataReader sqlDR;

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



        strSqlCmd = "select * from links";
        DS = DatabaseOperating.fillDataSet(strSqlCmd, "links");
        grdViwLinks.DataSource = DS;
        grdViwLinks.DataBind();

    }
    protected void btnLinkModify_Click(object sender, EventArgs e)
    {
        btnLinkModifyAddSubmit.Text = "修改";
        Button btnLinkModify = (Button) sender;
        strSqlCmd = "select * from links where linkID = '"+btnLinkModify.CommandArgument.ToString()+"' order by linkID" ;
        sqlDR = DatabaseOperating.sqlDataReaderRead(strSqlCmd);
        lblLinkID.Text = btnLinkModify.CommandArgument.ToString();
        txtLinkURL.Text = sqlDR["linkURL"].ToString();
        txtLinkName.Text = sqlDR["linkName"].ToString();
        txtLinkContent.Text = sqlDR["linkContent"].ToString();
    }
    protected void btnLinkDelete_Click(object sender, EventArgs e)
    {
        Button btnLinkDelete = (Button)sender;
        strSqlCmd = "delete from links where linkID = '" + btnLinkDelete.CommandArgument.ToString()+ "'";
        DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
        this.Page_Load(sender, e);

    }
    protected void btnLinkAdd_Click(object sender, EventArgs e)
    {
        
        lblLinkID.Text = "此项自动添加";
        btnLinkModifyAddSubmit.Text = "添加";
        txtLinkURL.Text = "http://";
        txtLinkName.Text = "";
        txtLinkContent.Text = "";

    }
    protected void btnLinkModifyAddSubmit_Click(object sender, EventArgs e)
    {


        if (btnLinkModifyAddSubmit.Text.Equals("修改"))
        {
            strSqlCmd = "update links set linkName = '" + txtLinkName.Text + "', linkURL = '" + txtLinkURL.Text + "', linkContent = '" + txtLinkContent.Text + "' where linkID = '" + lblLinkID.Text + "'";
            DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);
            lblLinkID.Text = "";
            txtLinkURL.Text = "http://";
            txtLinkName.Text = "";
            txtLinkContent.Text = "";
            this.Page_Load(sender, e);
        }
        else
        {
            SqlConnection sqlCnn = DatabaseOperating.creatDBConnect();
            SqlCommand sqlCmd = new SqlCommand("linkInsert",sqlCnn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            
            sqlCmd.Parameters.Add("@linkURl",SqlDbType.VarChar,200);
            sqlCmd.Parameters["@linkURL"].Value = txtLinkURL.Text;
            sqlCmd.Parameters.Add("@linkName",SqlDbType.VarChar,20);
            sqlCmd.Parameters["@linkName"].Value = txtLinkName.Text;
            sqlCmd.Parameters.Add("@linkContent",SqlDbType.VarChar,200);
            sqlCmd.Parameters["@linkContent"].Value = txtLinkContent.Text;

            sqlCmd.ExecuteNonQuery();

            sqlCnn.Close();









            //strSqlCmd = "insert into links (linkURL,linkName,linkContent) values ('" + txtLinkURL.Text + "','" + txtLinkName.Text + "','" + txtLinkContent.Text + "')";
            //DatabaseOperating.sqlCmdInsertDeleteUpdate(strSqlCmd);










            Response.Write("<script>alert('添加成功')</script>");
            lblLinkID.Text = "";
            txtLinkURL.Text = "http://";
            txtLinkName.Text = "";
            txtLinkContent.Text = "";
            this.Page_Load(sender,e);
        
        }
        Response.Write("<script>alert('操作成功')</script>");
    }
    protected void lnkBtnLinkName_Click(object sender, EventArgs e)
    {
        LinkButton strLinkURL = (LinkButton)sender;
        Response.Write("<script>window.location.href = '" + strLinkURL.CommandArgument.ToString() + "'</script>");
    }
}
