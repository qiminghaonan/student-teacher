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
    public partial class change : Form
    {
        public change()
        {
            InitializeComponent();
        }

        private void change_Load(object sender, EventArgs e)
        {
            string usname;
            usname = login.curuser;
            textBox1.Text = usname;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox2.Text)
            {
                string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string usname;
                usname = login.curuser;
                string sql = "select * from student where sname = '" + usname + "'";
                SqlCommand a = new SqlCommand("",conn);
                a.CommandText = sql;
                if (null != a.ExecuteScalar())
                {
                    string a1 = "update student set password = '" + textBox2.Text.Trim() + "'where sname = '" + usname + "' ";
                    SqlCommand sql1 = new SqlCommand("",conn);
                    sql1.CommandText = a1;
                    int c = sql1.ExecuteNonQuery();
                    if (c > 0)
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
                if (null == a.ExecuteScalar())
                {
                    string a1 = "update teacher set password = '" + textBox2.Text.Trim() + "'where tname =  '" + usname + "'";
                    SqlCommand sql1 = new SqlCommand("",conn);
                    sql1.CommandText = a1;
                    int c = sql1.ExecuteNonQuery();
                    if (c > 0)
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
            else
            {
                var f = new fail();
                f.Show();
                textBox2.Text = null;
                textBox3.Text = null;
            }
        }

    }
            
}
