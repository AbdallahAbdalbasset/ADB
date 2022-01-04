using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
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
                        var allmem = Form3.l.Database.SqlQuery<member>("select * from member where id = " + textBox2.Text).ToList<member>();
                        member m;
                        if (allmem.Count() > 0)
                        {
                            m = allmem[0];
                            if (m.id != Convert.ToInt32(textBox2.Text))
                                Form3.l.Database.ExecuteSqlCommand("insert into member values(" + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," + "'" + textBox4.Text + "')");
                        }

                        else
                            Form3.l.Database.ExecuteSqlCommand("insert into member values(" + "'" + textBox2.Text + "'," + "'" + textBox3.Text + "'," + "'" + textBox4.Text + "')");
                        Form3.l.Database.ExecuteSqlCommand("insert into borrow(id,book_id,member_id,borrow_date) values(" + Form3.l.borrows.Count() + "," + "" + textBox1.Text + "," + "" + textBox2.Text + ",'" + DateTime.Now + "'" + ")");
                    }
                    else
                        MessageBox.Show("no copies");
                }


            }
            catch(Exception c)
            {
                MessageBox.Show(c.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var r = Form3.l.Database.SqlQuery<book>("select * from book ").ToList<book>();
            dataGridView1.DataSource = r;
        }
    }
}
