using System.Data;
using System.Configuration;
using System.Data.SqlClient;


/// <summary>
/// MyDataSet 的摘要说明
/// </summary>
public class DatabaseOperating
{
    public DatabaseOperating()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}

    public static SqlConnection creatDBConnect()
    {
        SqlConnection sqlCnnDBCnn;

        try
        {
            //string strDBCnn = "Data Source=TLSLT\\;Initial Catalog=Yuchen;Integrated Security=True;Asynchronous Processing=true; uid = sa;pwd= ";
            //不支持网络访问的数据库连接字符串
            string strDBCnn = ConfigurationManager.ConnectionStrings["CnnStrYuchen"].ConnectionString.ToString();
            // 注意：在Web.config文件中添加连接字符串时“<add name="连接字符串名称" connectionString = "连接字符串" />”中的“add”“name”“connectionString”开头字母都要小写！



            //支持网络访问的数据库连接字符串
            //在本机测试生成的时候，Persist Security Info参数的值不影响数据库访问，故为缺省。
            //在网络上访问的时候（直接使用别的机器的数据库的时候），会将其设置为true，即连接之后仍保留连接信息，可供以后使用。
            //生成方法：使用数据源控件直接连接别的机器的数据库。


            sqlCnnDBCnn = new SqlConnection(strDBCnn);
            sqlCnnDBCnn.Open();
            return sqlCnnDBCnn;

        }
        catch
        {

        }

        return null;
    }// 创建数据库连接



    public static DataSet fillDataSet(string strSqlCmd, string strTblName)
    {
        try
        {
            SqlConnection sqlCnn = DatabaseOperating.creatDBConnect();
            SqlDataAdapter sqlDA = new SqlDataAdapter(strSqlCmd, sqlCnn);
            DataSet DS = new DataSet();
            sqlDA.Fill(DS, strTblName);
            sqlCnn.Close();
            return DS;

        }

        catch 
        { 
        }


        return null;

    }// 新建DataSet并填充


    public static SqlDataReader sqlDataReaderRead(string strSqlCmd)
    {
        try
        {
            SqlConnection sqlCnn = DatabaseOperating.creatDBConnect();
            SqlCommand sqlCmd = new SqlCommand(strSqlCmd, sqlCnn);
            SqlDataReader sqlDR = sqlCmd.ExecuteReader();

            if (sqlDR.Read())                                                      // 注意这三句的顺序。“.Read()”的存在依赖于数据库连接。
            {
                return sqlDR;
            }
            else
            {
                return null;
            }
            
            sqlCnn.Close();
        }

        catch { }

        return null;
    }// 新建SqlDataReader并read数据

    public static void sqlCmdInsertDeleteUpdate(string strSqlCmd) 
    {
        try
        {
            SqlConnection sqlCnn = DatabaseOperating.creatDBConnect();
            SqlCommand sqlCmd = new SqlCommand(strSqlCmd, sqlCnn);
            sqlCmd.ExecuteNonQuery();
            sqlCnn.Close();
        }
        catch { }

        return;
    }// 数据库增，删，改命令


}
