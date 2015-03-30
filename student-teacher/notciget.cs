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
    public partial class notciget : Form
    {               
        
        public notciget()
        {
            InitializeComponent();
        }


        private void notciget_Load(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string usname = login.curuser;
            string sql1 = "select distinct cname from course,notice,teacher,student,coustu,coutea where notice.cid = course.cid and coustu.sid = student.sid and sname = '"+usname+"' and coustu.cid = course.cid";
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = sql1;
            string sel;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql1, conn);
            sqldap.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sel = dt.Rows[i][0].ToString();
                comboBox1.Items.Add(sel);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstr = ConfigurationManager.ConnectionStrings["myconn"].ConnectionString;
            SqlConnection conn = new SqlConnection(connstr);
            conn.Open();
            string na;
            na = comboBox1.Text;
            string sql2 = "select comment from course,notice where course.cid=notice.cid and cname ='"+na+"'";
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandText = sql2;
            DataTable dt = new DataTable();
            SqlDataAdapter sqldap = new SqlDataAdapter(sql2, conn);
            sqldap.Fill(dt);
            string not;
            not = dt.Rows[0][0].ToString();
            richTextBox1.Text = not;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}
