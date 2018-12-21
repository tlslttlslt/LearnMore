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
using SQLDMO;


public partial class management_DBBackup : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userRight"] == null || !Session["userRight"].ToString().Equals("1"))
        {

            Response.Write("<script language=\"javascript\"> alert(\"对不起,你无此权限。请返回首页登录。\");window.location.href='Default.aspx'</script> ");

        }
        else
        {
            this.Master.pnlLoginDoneState.Visible = true;
            this.Master.pnlLoginState.Visible = false;
            this.Master.lblUserNameState.Text = Session["userName"].ToString();
        }


    }




    protected void btnDBBackup_Click(object sender, EventArgs e)
    {
        

        Backup dbBackup = new Backup();
        SQLServer sqlServer = new SQLServer();
        sqlServer.LoginSecure = false;
        sqlServer.Connect(".","sa","");
        dbBackup.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
        dbBackup.Database = "Yuchen";
        dbBackup.Files = @"C:\BackupOfYuchen\BackupOfYuchen.bak";//这些路径不会自己创建，不能有空格
        
        dbBackup.BackupSetName = "BackupOfYuchen";
        dbBackup.BackupSetDescription = "备份数据库Yuchen";
        dbBackup.Initialize = true;
        dbBackup.SQLBackup(sqlServer);

        sqlServer.DisConnect();

        Response.Write("<script language=\"javascript\">alert('已经将数据库备份到C:\\\\BackupOfYuchen')</script>");



    }
    protected void btnDBRecovery_Click(object sender, EventArgs e)
    {

        Restore dbRestore = new Restore();
        SQLServer sqlServer = new SQLServer();

        sqlServer.LoginSecure = false;
        sqlServer.Connect(".", "sa", "");
        dbRestore.Action = SQLDMO_RESTORE_TYPE.SQLDMORestore_Database;
        dbRestore.Database = "Yuchen";
        dbRestore.Files = @"C:\BackupOfYuchen\BackupOfYuchen.bak";//和上面的路径保持一致
        dbRestore.FileNumber = 1;
        dbRestore.ReplaceDatabase = true;
        dbRestore.SQLRestore(sqlServer);

        sqlServer.DisConnect();


    }
}
