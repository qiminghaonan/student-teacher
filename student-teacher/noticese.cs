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
    public partial class noticese : Form
    {
        public noticese()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void noticese_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string usname = login.curuser;
            string sql = "select cname from course,coutea,teacher where teacher.tid = coutea.tid and course.cid = coutea.cid and tname = '"+usname+"'";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = sql;
            string sel;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql, conn);
            sqldap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sel = dt.Rows[i][0].ToString();
                comboBox1.Items.Add(sel);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string notice;
            notice = richTextBox1.Text.Trim();
            string usname;
            usname = login.curuser;
            string a;
            string c = comboBox1.Text;
            a = "select notice.cid from notice,teacher,course,coutea where notice.cid = course.cid and teacher.tid = coutea.tid and course.cid = coutea.cid and tname = '" + usname + "' and cname = '"+comboBox1.Text+"'";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = a; 
            if (null != b.ExecuteScalar())
            {            
                string sel;
                DataTable dt = new DataTable();
                SqlDataAdapter sqldap = new SqlDataAdapter(a, conn);
                sqldap.Fill(dt);
                sel = dt.Rows[0][0].ToString();
                string sql1 = "update notice set comment = '" + notice + "' where cid = (select coutea.cid from coutea,teacher,course where cname = '"+comboBox1.Text+"' and teacher.tid = coutea.tid and course.cid = coutea.cid)";
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
                string sql1 = "insert into notice select coutea.cid,comment = '" + notice + "' from coutea,teacher,course where cname = '" + comboBox1.Text + "' and tname = '"+usname+"' and teacher.tid = coutea.tid and course.cid = coutea.cid";
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
