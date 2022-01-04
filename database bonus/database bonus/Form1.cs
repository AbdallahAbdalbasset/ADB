using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace database_bonus
{

    public partial class Form1 : Form
    {
        public int mod;

        Hashing[] table = new Hashing[2000];

       


        public Form1()
        {
            InitializeComponent();
        }
        Hashing temp = new Hashing();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mod = Convert.ToInt32(textBox2.Lines[0]);
                int check= mod/mod;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please insert the value of modulo");
               Close();
            }

            float counter = 0;


            for (int i = 0; i < mod; i++)
            {
                table[i] = new Hashing();
                table[i].hash = i;

            }

            for (int i = 0; i < textBox1.Lines.Length; i++)
            {
                Stopwatch stopwatch = new Stopwatch();
                string str;
                int res;
                
                stopwatch.Start();
                str = StringToBinary(textBox1.Lines[i]);
                res = getMod(str, str.Length, mod);
                stopwatch.Stop();

                listBox1.Items.Add(stopwatch.Elapsed);
                table[res].count++;
                table[res].hash = res;
                table[res].timeTake += stopwatch.Elapsed;
                if (table[res].count > 1)
                    counter++;



            }
            textBox3.Text = (((counter / textBox1.Lines.Length) * 100).ToString()+"%");
            dataGridView1.DataSource = table;




        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        public static int getMod(string str, int n, int k)
        {
            int i;

            // pwrTwo[i] will store ((2^i) % k)
            int[] pwrTwo = new int[n];
            int res = 0;
            try
            {
                pwrTwo[0] = 1 % k;


                for (i = 1; i < n; i++)
                {
                    pwrTwo[i] = pwrTwo[i - 1] * (2 % k);
                    pwrTwo[i] %= k;
                }


                // To store the result
                
                i = 0;
                int j = n - 1;
                while (i < n)
                {

                    // If current bit is 1
                    if (str[j] == '1')
                    {

                        // Add the current power of 2
                        res += (pwrTwo[i]);
                        res %= k;
                    }
                    i++;
                    j--;
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not enter null string");
            }
            return res;
        }
    }

public class Hashing
    {
        public int hash {get;set;}
        public int count { get; set; }
        public TimeSpan timeTake { get; set; }
    }
}
