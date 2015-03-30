using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace student_teacher
{
    public partial class tealo : Form
    {
        public tealo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form1 = new getmes();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form2 = new sendmes();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form3 = new noticese();
            form3.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var form4 = new teatable();
            form4.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new login();
            form.Show(); 
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var f = new change();
            f.Show();
        }
    }
}
