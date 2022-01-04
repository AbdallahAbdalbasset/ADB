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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1.form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var r = Form3.l.Database.SqlQuery<borrow>("select * from borrow ").ToList<borrow>();

            dataGridView1.DataSource = r;
        }

        private void Form8_Load(object sender, EventArgs e)
        {

        }
    }
}
