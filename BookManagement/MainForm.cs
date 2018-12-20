using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CmnClsLib_DB;
using System.Configuration;                 //此处的using和在引用中添加, 二者缺一不可


namespace BooKManagement
{



    public partial class MainForm : Form
    {
        string pstgrConnString = ConfigurationManager.ConnectionStrings["PgConn_MOBookManagement"].ConnectionString.ToString();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            DB_Oper_Pg pgOper = new DB_Oper_Pg();
            pgOper.PgConn_Open(pstgrConnString);


        }
    }
}
