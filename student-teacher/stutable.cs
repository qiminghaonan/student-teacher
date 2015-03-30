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
    public partial class stutable : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=tea-stu;Integrated Security=True");
        public stutable()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            textBox2.ReadOnly = false; 
            textBox3.ReadOnly = false; 
            textBox4.ReadOnly = false;
            textBox5.ReadOnly = false;
            textBox6.ReadOnly = false;
            textBox7.ReadOnly = false;
            textBox8.ReadOnly = false;
            textBox9.ReadOnly = false;
            textBox10.ReadOnly = false;
            textBox11.ReadOnly = false;
            textBox12.ReadOnly = false;
            textBox13.ReadOnly = false;
            textBox14.ReadOnly = false;
            textBox15.ReadOnly = false;
            textBox16.ReadOnly = false;
            textBox17.ReadOnly = false;
            textBox18.ReadOnly = false;
            textBox19.ReadOnly = false;
            textBox20.ReadOnly = false;
            textBox21.ReadOnly = false;
            textBox22.ReadOnly = false;
            textBox23.ReadOnly = false;
            textBox24.ReadOnly = false;
            textBox25.ReadOnly = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void stutable_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string a;
            string usname;
            usname = login.curuser;
            a = "select * from tab,tabstu,student where student.sid=tabstu.sid and tabstu.taid = tab.taid and sname = '"+usname+"'";
            SqlCommand b = new SqlCommand("", conn);
            b.CommandText = a;
            if(null !=b.ExecuteScalar())
            {
                DataTable dt = new DataTable();
                SqlDataAdapter sqldap = new SqlDataAdapter(a, conn);
                sqldap.Fill(dt);
                textBox1.Text = dt.Rows[0][1].ToString();
                textBox2.Text = dt.Rows[0][2].ToString();
                textBox3.Text = dt.Rows[0][3].ToString();
                textBox4.Text = dt.Rows[0][4].ToString();
                textBox5.Text = dt.Rows[0][5].ToString();
                textBox6.Text = dt.Rows[0][6].ToString();
                textBox7.Text = dt.Rows[0][7].ToString();
                textBox8.Text = dt.Rows[0][8].ToString();
                textBox9.Text = dt.Rows[0][9].ToString();
                textBox10.Text = dt.Rows[0][10].ToString();
                textBox11.Text = dt.Rows[0][11].ToString();
                textBox12.Text = dt.Rows[0][12].ToString();
                textBox13.Text = dt.Rows[0][13].ToString();
                textBox14.Text = dt.Rows[0][14].ToString();
                textBox15.Text = dt.Rows[0][15].ToString();
                textBox16.Text = dt.Rows[0][16].ToString();
                textBox17.Text = dt.Rows[0][17].ToString();
                textBox18.Text = dt.Rows[0][18].ToString();
                textBox19.Text = dt.Rows[0][19].ToString();
                textBox20.Text = dt.Rows[0][20].ToString();
                textBox21.Text = dt.Rows[0][21].ToString();
                textBox22.Text = dt.Rows[0][22].ToString();
                textBox23.Text = dt.Rows[0][23].ToString();
                textBox24.Text = dt.Rows[0][24].ToString();
                textBox25.Text = dt.Rows[0][25].ToString();
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usname;
            usname = login.curuser;
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            textBox9.ReadOnly = true;
            textBox10.ReadOnly = true;
            textBox11.ReadOnly = true;
            textBox12.ReadOnly = true;
            textBox13.ReadOnly = true;
            textBox14.ReadOnly = true;
            textBox15.ReadOnly = true;
            textBox16.ReadOnly = true;
            textBox17.ReadOnly = true;
            textBox18.ReadOnly = true;
            textBox19.ReadOnly = true;
            textBox20.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox22.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox24.ReadOnly = true;
            textBox25.ReadOnly = true;
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string se = "select * from student,tabstu where sname = '" + usname + "' and tabstu.sid = student.sid";
            SqlCommand com = new SqlCommand("", conn);
            com.CommandText = se;
            if (null != com.ExecuteScalar())
            {
                string a = "update tab set yi1='" + textBox1.Text + "',yi2='" + textBox2.Text + "',yi3='" + textBox3.Text + "',yi4='" + textBox4.Text + "',yi5='" + textBox5.Text + "',er1 ='" + textBox6.Text + "',er2='" + textBox7.Text + "',er3='" + textBox8.Text + "',er4='" + textBox9.Text + "',er5='" + textBox10.Text + "',san1='" + textBox11.Text + "',san2='" + textBox12.Text + "',san3='" + textBox13.Text + "',san4='" + textBox14.Text + "',san5='" + textBox15.Text + "',si1='" + textBox16.Text + "',si2='" + textBox17.Text + "',si3='" + textBox18.Text + "',si4='" + textBox19.Text + "',si5='" + textBox20.Text + "',wu1='" + textBox21.Text + "',wu2='" + textBox22.Text + "',wu3='" + textBox23.Text + "',wu4='" + textBox24.Text + "',wu5='" + textBox25.Text + "' where taid = (select taid from tabstu,student where sname = '" + usname + "' and tabstu.sid = student.sid)";
                SqlCommand b = new SqlCommand("", conn);
                b.CommandText = a;
                int num = b.ExecuteNonQuery();
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
            if (null == com.ExecuteScalar())
            {
                string a = "insert into tab(yi1,yi2,yi3,yi4,yi5,er1,er2,er3,er4,er5,san1,san2,san3,san4,san5,si1,si2,si3,si4,si5,wu1,wu2,wu3,wu4,wu5) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox12.Text + "','" + textBox13.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "','" + textBox20.Text + "','" + textBox21.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + textBox24.Text + "','" + textBox25.Text + "')";
                SqlCommand b = new SqlCommand("", conn);
                b.CommandText = a;
                int num = b.ExecuteNonQuery();
                string c = "insert into tabstu select max(taid),student.sid from student,tab where sname = '" + usname + "' group by sid ";
                SqlCommand d = new SqlCommand("", conn);
                d.CommandText = c;
                int num1 = d.ExecuteNonQuery();
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
            }
     
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var f = new infor();
            this.Visible = false;
            f.Show();
        }
    }
}
