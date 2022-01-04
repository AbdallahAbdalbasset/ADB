using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(textBox1.Text != "")
            {
                try
                {
                    var r = Form3.l.Database.SqlQuery<book>("select * from book where id = " + textBox1.Text).ToList<book>();
                    dataGridView1.DataSource = r;
                }
                catch(Exception c)
                {
                    MessageBox.Show("Enter a valid book id");
                }
                
            }
            
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            var r =  Form3.l.Database.SqlQuery<book>("select * from book ").ToList<book>();
            
            dataGridView1.DataSource = r;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = Form3.l.Database.SqlQuery<book>("select * from book ").ToList<book>();
            dataGridView1.DataSource = r;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form2.Show();
        }
    }
}
