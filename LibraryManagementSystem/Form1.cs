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
    public partial class Form1 : Form
    {
        public static Form1 form1 = new Form1();
        public static Form2 form2 = new Form2();
        
        public static Form3 form3 = new Form3();
        public static Form4 form4 = new Form4();
        public static Form5 form5 = new Form5();
        public static Form6 form6 = new Form6();
        public static Form7 form7 = new Form7();
        public static Form8 form8 = new Form8();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            form1.Hide();
            form2.Hide();
            form3.Hide();
            form4.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (textBox1.Text == "username" && textBox2.Text == "pass")
            {
                
                this.Hide();
                form2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
