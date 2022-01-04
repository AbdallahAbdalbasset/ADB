using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void deleteselecteditem_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {


                    var b = Form3.l.Database.SqlQuery<book>("select * from book where id = " + textBox1.Text).ToList<book>();
                    book bb = b[0];

                    if (bb.copies_owned > 0)
                    {
                        Form3.l.Database.ExecuteSqlCommand("UPDATE book SET copies_owned = copies_owned - 1  WHERE id =" + textBox1.Text);
                        MessageBox.Show("deleted");
                    }
                    else
                        MessageBox.Show("not enough books");
                }
                    
            }
            catch(Exception c)
            {
                MessageBox.Show(c.Message);
            }
            
            
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = Form3.l.Database.SqlQuery<book>("select * from book ").ToList<book>();

            dataGridView1.DataSource = r;
        }
    }
}
