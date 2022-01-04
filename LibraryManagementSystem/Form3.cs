using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity.Migrations;
using System.Globalization;

namespace LibraryManagementSystem
{
    public partial class Form3 : Form
    {
        public static LibraryManagementSystemEntities4 l = new LibraryManagementSystemEntities4();
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
            try
            {
                book b = new book
                {
                    id = Convert.ToInt32(textBox1.Text),
                    title = maskedTextBox1.Text,
                    category = maskedTextBox2.Text,
                    publication_date = dateTimePicker1.Value,
                    copies_owned = 1
                };
                author a = new author
                {
                    id = l.authors.Count(),
                    name = maskedTextBox4.Text
                };
                bool ok = true;
                string x = textBox1.Text;
               
                foreach(book bb in l.books)
                {
                    if(bb.id == Convert.ToInt32(x))
                    {
                        b.copies_owned =Convert.ToInt32( bb.copies_owned)+1;
                        

                        b.id = bb.id;
                        b.title = bb.title;
                        b.category = bb.category;
                        
                        ok = false;
                        break;
                    }
                }
                if(ok == false)
                {
                    
                    l.books.AddOrUpdate(b);
                    l.SaveChanges();
                    MessageBox.Show("updated");
                }
                
                if(ok == true)
                {
                    l.books.Add(b);
                    l.SaveChanges();
                    
                    int xx = -1;
                    foreach (author bb in l.authors)
                    {
                        if (bb.name == maskedTextBox4.Text)
                        {
                            xx = bb.id;                           
                        }
                    }
                    if(xx ==-1)
                    {
                        l.authors.Add(a);
                        MessageBox.Show("author : "+ a.id + " " + a.name);
                        l.SaveChanges();
                        
                        xx = l.authors.Count()-1;
                    }

                    book_author ba = new book_author
                    {
                        id = l.book_author.Count(),
                        book_id = Convert.ToInt32(textBox1.Text),
                        author_id = xx
                    };
                    MessageBox.Show("book_author: "+ba.id + " " + ba.book_id+" " + ba.author_id);
                    l.book_author.Add(ba);
                    l.SaveChanges();
                    MessageBox.Show("added successfully");

                }
                    
                
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form2.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
