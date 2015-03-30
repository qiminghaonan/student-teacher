using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace student_teacher
{
    public partial class sendmes : Form
    {
        public sendmes()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sendmes_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string to;
            to = textBox1.Text.Trim();
            string usname;
            usname = login.curuser;
            string me = richTextBox1.Text.Trim();
            string a = "select comid from comment where tona = '"+to+"' and fromna = '"+usname+"'";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = a;
            if (null != b.ExecuteScalar())
            {
                string sql1 = "update comment set comment = '" + me + "' where tona = '" + to + "' and fromna = '" + usname + "'";
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = sql1;
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
            if (null == b.ExecuteScalar())
            {
                string sql1 = "insert into comment(comment,fromna,tona) values('" + me + "','" + usname + "','" + to + "')";
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandText = sql1;
                int num = cmd.ExecuteNonQuery();
                if (num > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
        }
    }
}
