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
    public partial class ma : Form
    {
        public ma()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new login();
            form.Show();
            this.Close();
        }

        private void ma_Load(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string usname = login.curuser;
            if (radioButton3.Checked)
            {
                string sql = "select sname from student where sname like '%" + textBox4.Text + "%'";
                SqlCommand b = new SqlCommand("", conn);
                b.CommandText = sql;
                string sel;
                DataTable dt = new DataTable();
                SqlDataAdapter sqldap = new SqlDataAdapter(sql, conn);
                sqldap.Fill(dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    sel = dt.Rows[i][0].ToString();
                    listBox1.Items.Add(sel);
                }
                int count = listBox1.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    string str = listBox1.Items[i].ToString();
                    for (int j = i + 1; j < count; j++)
                    {
                        string str1 = listBox1.Items[j].ToString();
                        if (str1 == str)
                        {
                            listBox1.Items.RemoveAt(j);
                            count--;
                            j--;
                        }
                    }
                }
            }
            if (radioButton4.Checked)
            {
                string sql1 = "select tname from teacher where tname like '%" + textBox4.Text + "%'";
                SqlCommand b1 = new SqlCommand("", conn);
                b1.CommandText = sql1;
                string sel1;
                DataTable dt1 = new DataTable();
                SqlDataAdapter sqldap1 = new SqlDataAdapter(sql1, conn);
                sqldap1.Fill(dt1);
                for (int i = 0; i < dt1.Rows.Count; i++)
                {
                    sel1 = dt1.Rows[i][0].ToString();
                    listBox1.Items.Add(sel1);
                }
                int count1 = listBox1.Items.Count;
                for (int i = 0; i < count1; i++)
                {
                    string str = listBox1.Items[i].ToString();
                    for (int j = i + 1; j < count1; j++)
                    {
                        string str1 = listBox1.Items[j].ToString();
                        if (str1 == str)
                        {
                            listBox1.Items.RemoveAt(j);
                            count1--;
                            j--;
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string na = listBox1.SelectedItem.ToString();
            if (radioButton3.Checked)
            {
                string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string sql = "delete from student where sname = '" + na + "'";
                SqlCommand com = new SqlCommand("", conn);
                com.CommandText = sql;
                int a = com.ExecuteNonQuery();
                if (a > 0)
                {
                    var f = new success();
                    f.Show();
                    listBox1.Items.Clear();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
            if (radioButton4.Checked)
            {
                string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
                SqlConnection conn = new SqlConnection(connstr);
                conn.Open();
                string sql = "delete from teacher where tname = '" + na + "'";
                SqlCommand com = new SqlCommand("", conn);
                com.CommandText = sql;
                int a = com.ExecuteNonQuery();
                if (a > 0)
                {
                    var f = new success();
                    f.Show();
                    listBox1.Items.Clear();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            if (radioButton1.Checked)
            {
                string id = textBox1.Text;
                string na = textBox2.Text;
                string pa = textBox3.Text;
                string s = "insert into student values('" + id + "','" + na + "','" + pa + "')";
                SqlCommand com = new SqlCommand("", conn);
                com.CommandText = s;
                int a = com.ExecuteNonQuery();
                if (a > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
            if (radioButton2.Checked)
            {
                string id = textBox1.Text;
                string na = textBox2.Text;
                string pa = textBox3.Text;
                string s = "insert into teacher values('" + id + "','" + na + "','" + pa + "')";
                SqlCommand com = new SqlCommand("", conn);
                com.CommandText = s;
                int a = com.ExecuteNonQuery();
                if (a > 0)
                {
                    var f = new success();
                    f.Show();
                }
                else
                {
                    var f = new fail();
                    f.Show();
                }
                textBox1.Text = null;
                textBox2.Text = null;
                textBox3.Text = null;
            }
        }
    }
}
