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
    public partial class infor : Form
    {
        public infor()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var f = new stutable();
            f.Show();
        }

        private void infor_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string usname;
            usname = login.curuser;
            string sql1 = "select yi1,yi2,yi3,yi4,yi5,er1,er2,er3,er4,er5,san1,san2,san3,san4,san5,si1,si2,si3,si4,si5,wu1,wu2,wu3,wu4,wu5 from tab,tabstu,student where sname='" + usname + "' and tabstu.sid = student.sid and tab.taid=tabstu.taid";
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = sql1;
            string sel;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql1, conn);
            sqldap.Fill(dt);
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sel = dt.Rows[0][i].ToString();
                if (sel != null||sel != "")
                {
                    comboBox1.Items.Add(sel);
                }
            }
            int count = comboBox1.Items.Count;
            for (int i = 0; i < count; i++)
            {
                string str = comboBox1.Items[i].ToString();
                for (int j = i + 1; j < count; j++)
                {
                    string str1 = comboBox1.Items[j].ToString();
                    if (str1 == str)
                    {
                        comboBox1.Items.RemoveAt(j);
                        count--;
                        j--;
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
                string usname = login.curuser;
                string cname = comboBox1.Text;
                string sql1 = "select * from course,student,coustu where cname = '" + cname + "' and sname = '" + usname + "'and course.cid = coustu.cid and student.sid = coustu.sid";
                SqlCommand b = new SqlCommand("", conn);
                b.CommandText = sql1;
                if (null == b.ExecuteScalar())
                {
                    var f = new cba();
                    f.Show();
                }
                if (null != b.ExecuteScalar())
                {
                    textBox1.Text = comboBox1.Text;
                    string sq1 = "select location from course,teacher,coutea where cname = '" + cname + "' and tname = '" + comboBox2.Text + "' and teacher.tid = coutea.tid and course.cid = coutea.cid";
                    SqlCommand s1 = new SqlCommand("", conn);
                    s1.CommandText = sq1;
                    DataTable dt1 = new DataTable();
                    SqlDataAdapter sqldap1 = new SqlDataAdapter(sq1, conn);
                    sqldap1.Fill(dt1);
                    textBox2.Text = dt1.Rows[0][0].ToString();
                    string sq2 = "select time from course,teacher,coutea where cname = '" + cname + "'and tname = '" + comboBox2.Text + "' and teacher.tid = coutea.tid and course.cid = coutea.cid";
                    SqlCommand s2 = new SqlCommand("", conn);
                    s1.CommandText = sq2;
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter sqldap2 = new SqlDataAdapter(sq2, conn);
                    sqldap2.Fill(dt2);
                    textBox3.Text = dt2.Rows[0][0].ToString();
                    string sq3 = "select count(distinct sid) from course,coustu where cname = '" + cname + "' and coustu.cid = course.cid";
                    SqlCommand s3 = new SqlCommand("", conn);
                    s1.CommandText = sq3;
                    DataTable dt3 = new DataTable();
                    SqlDataAdapter sqldap3 = new SqlDataAdapter(sq3, conn);
                    sqldap3.Fill(dt3);
                    textBox4.Text = dt3.Rows[0][0].ToString();
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string usname = login.curuser;
            string cname = comboBox1.Text;
            string sql1 = "select * from course,student,coustu where cname = '" + cname + "' and sname = '" + usname + "'and course.cid = coustu.cid and student.sid = coustu.sid";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = sql1;            
            if (null != b.ExecuteScalar())
            {
                var f = new abc();
                f.Show();
            }
            if (null == b.ExecuteScalar())
            {
                string sql = "insert into coustu select cid,sid from coutea,student,teacher where sname = '" + usname + "' and tname = '"+comboBox2.Text+"' and coutea.tid = teacher.tid";
                SqlCommand com = new SqlCommand("", conn);
                com.CommandText = sql;
                int a = com.ExecuteNonQuery();
                if (a > 0)
                {
                    var f = new success();
                    f.Show();
                    comboBox2.Items.Clear();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                    comboBox2.Items.Clear();
                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string course = comboBox1.Text;
            string sql = "select tname from course,coutea,teacher where cname = '"+course+"'and teacher.tid = coutea.tid and course.cid = coutea.cid";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = sql;
            if (null != b.ExecuteScalar())
            {
                string sel;
                DataTable dt = new DataTable();
                SqlDataAdapter sqldap = new SqlDataAdapter(sql, conn);
                sqldap.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sel = dt.Rows[i][0].ToString();
                    if (sel != null || sel != "")
                    {
                        comboBox2.Items.Add(sel);
                    }
                }
                int count = comboBox2.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    string str = comboBox2.Items[i].ToString();
                    for (int j = i + 1; j < count; j++)
                    {
                        string str1 = comboBox2.Items[j].ToString();
                        if (str1 == str)
                        {
                            comboBox2.Items.RemoveAt(j);
                            count--;
                            j--;
                        }
                    }
                }
            }
        }
    }
}
