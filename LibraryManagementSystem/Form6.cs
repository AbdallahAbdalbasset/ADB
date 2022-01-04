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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text!=""||textBox2.Text!="")
                {
                    var r = Form3.l.Database.SqlQuery<borrow>("select * from borrow where book_id = " + textBox1.Text + " and member_id = " + textBox2.Text).ToList<borrow>();
                    borrow b;

                    if (r.Count() > 0)
                    {
                        b = r[0];
                        string x = (b.returned_date).ToString();
                        if (x != "")
                        {

                            MessageBox.Show("this book returned");
                        }
                        else
                        {

                            Form3.l.Database.ExecuteSqlCommand("UPDATE book SET copies_owned = copies_owned + 1  WHERE id =" + textBox1.Text);
                            Form3.l.Database.ExecuteSqlCommand("UPDATE borrow SET returned_date ='" + DateTime.Now + "' WHERE book_id =" + textBox1.Text + " and member_id = " + textBox2.Text);

                        }
                    }
                    else
                        MessageBox.Show("no borrowed books to return");
                    
                    
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
    }
}
