using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace student_teacher
{
    public partial class addclass : Form
    {
        public addclass()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var n = new teatable();
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string sql1 = "insert into course(cname,location,time) values('" + textBox1.Text.Trim() + "','" + textBox2.Text.Trim() + "','" + textBox3.Text.Trim() + "' )";
            SqlCommand a = new SqlCommand("", conn);
            a.CommandText = sql1;
            int num = a.ExecuteNonQuery();
            string usname = login.curuser;
            string sql2 = "insert into coutea select max(cid),tid from course,teacher where tname = '"+usname+"'group by teacher.tid";
            SqlCommand b= new SqlCommand("", conn);
            b.CommandText = sql2;
            int num1 = b.ExecuteNonQuery();
            if (num > 0 && num1 > 0)
            {
                var f = new success();
                f.Show();
            }
            else
            {
                var f = new fail();
                f.Show();
            }
            conn.Close();
            this.Visible = false;
        }

        private void addclass_Load(object sender, EventArgs e)
        {

        }
    }
}
