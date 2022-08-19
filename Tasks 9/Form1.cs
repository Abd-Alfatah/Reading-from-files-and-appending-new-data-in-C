using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tasks_9

{
    public partial class Form1 : Form
    {

        string[] name_arry;
        string[] place_array;
        string[] age_array;
        string[] Mothername_array;
        public Form1()
        {
            InitializeComponent();
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox10.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            label2.Visible = false;
            label1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;

        }
        static int count()
        {
            int n = 0;
            StreamReader f = new StreamReader("Tasks.txt");

            while (!f.EndOfStream)
            {
                f.ReadLine();
                n++;
            }
            f.Close();
            return n;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox5.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;

            string new_name = textBox5.Text;
            string new_age = textBox6.Text;
            string new_plce = textBox7.Text;
            string new_mother = textBox8.Text;
            string line =  new_name + ("*") + new_age + ("*") + new_plce + ("*") + new_mother + ("*");
            StreamWriter f = new StreamWriter("Tasks.txt" ,true);
            f.WriteLine(line);
            f.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            label2.Visible = true;
            label1.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            string line;
            StreamReader f = new StreamReader("Tasks.txt");
            int n = count();
            name_arry = new string[n];
            age_array = new string[n];
            place_array = new string[n];
            Mothername_array = new string[n];
            int j = 0;
            int i;
            
            while (!f.EndOfStream)
            {
                 line = f.ReadLine();

                
                i = line.IndexOf("*");
                name_arry[j]= line.Substring(0, i);
                line = line.Remove(0, i+1);

                i = line.IndexOf("*");
                place_array[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                age_array[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);
                

                i = line.IndexOf("*");
                Mothername_array[j] = line.Substring(0, i);
                j++;
            }
            for (int k = 0; k < n; k++)
            {
               textBox1.Text += name_arry[k] + Environment.NewLine;
                textBox2.Text += age_array[k] + Environment.NewLine;
                textBox3.Text += place_array[k] + Environment.NewLine;
                textBox4.Text += Mothername_array[k] + Environment.NewLine;
            }
            f.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox9.Visible = true;
            int n = count();
            StreamReader f = new StreamReader("Tasks.txt");
            age_array = new string[n];
            place_array = new string[n];
            int j = 0;
            int i;
            while (!f.EndOfStream)
            {
                string line = f.ReadLine();

                i = line.IndexOf("*");
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                age_array[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                place_array[j] = line.Substring(0, i);
                j += 1;
            }
            double sum = 1;
            double s=0;
            double d = 0;
            


            
            for (int k = 0; k < n; k++)
            {
                for (int m = 0; m < n; m++)
                {
                    if (place_array[k] == place_array[m]&&k!=m)
                    {
                        sum += 1;
                        d = double.Parse(age_array[k]);
                        s +=double.Parse( age_array[m]);
                        
                    }
                }
                //place_array[k].Remove(0,k+1);
                double average = (s + d) / (sum);
                textBox9.Text = average.ToString();

                sum = 1;
                s = 0;

            }
            f.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox10.Visible = true;
            textBox10.Clear();
            StreamReader f = new StreamReader("Tasks.txt");
            int n = count();
            name_arry = new string[n];
            Mothername_array = new string[n];
            int j = 0;
            int i;
            while (!f.EndOfStream)
            {
                string line = f.ReadLine();

                i = line.IndexOf("*");
                name_arry[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                Mothername_array[j] = line.Substring(0, i);
                j++;
            }
            string s="";
            string p="";
            for (int k = 0; k < n; k++)
            {
                
                for (int m = 1; m < n; m++)
                {
                    if (Mothername_array[k] == Mothername_array[m]&&k!=m)
                    {
                        if (m != 0)
                        { s = Environment.NewLine; }
                        s += name_arry[k] ;
                        
                    }
                }
                textBox10.Text += s;
                s = "";
                p = "";
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string line;
            StreamReader f = new StreamReader("Tasks.txt");
            int n = count();
            name_arry = new string[n];
            age_array = new string[n];
            place_array = new string[n];
            Mothername_array = new string[n];
            int j = 0;
            int i;

            while (!f.EndOfStream)
            {
                line = f.ReadLine();

                i = line.IndexOf("*");
                name_arry[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                place_array[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);

                i = line.IndexOf("*");
                age_array[j] = line.Substring(0, i);
                line = line.Remove(0, i + 1);


                i = line.IndexOf("*");
                Mothername_array[j] = line.Substring(0, i);
                j++;
            }
         
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Visible = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
