using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mine
{
    public partial class Form1 : Form
    {
        Button[,] b;
        int x, y, z, nr = 0;
        int dim = 20;
        Class1 A;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Input string is not a sequence of digits.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                y = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Input string is not a sequence of digits.");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                z = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException exp)
            {
                MessageBox.Show("Input string is not a sequence of digits.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            A = new Class1(x, y, z);
            b = new Button[x + 1, y + 1];
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            //label3.Visible = false;
            //label4.Visible = false;
            int i, j;
            this.Size = new Size((dim + 1) * x, (dim + 3) * y);
            for (i = 1; i <= x; i++)
                for (j = 1; j <= y; j++)
                {
                    b[i, j] = new Button();
                    b[i, j].Location = new Point((i - 1) * dim, (j - 1) * dim);
                    b[i, j].Size = new Size(dim, dim);
                    b[i, j].BackColor = Color.Azure;
                    b[i, j].MouseUp += new MouseEventHandler(button_MouseClick);
                    Controls.Add(b[i, j]);
                    b[i, j].Visible = true;
                }
        }
            void button_MouseClick(object sender, MouseEventArgs e)
            {
                Button b=(Button) sender;
                if(e.Button==MouseButtons.Right)
                {
                    int i=b.Location.X/dim+1;
                    int j=b.Location.Y/dim+1;
                    if(b.Text=="b")
                        b.Text="";
                    else
                        b.Text="b";
                }
                if(e.Button==MouseButtons.Left)
                {
                    int i=b.Location.X/dim+1;
                    int j=b.Location.Y/dim+1;
                    b.BackColor=Color.White;
                    if(A.get(i, j)==1)
                    {
                        MessageBox.Show("Ai pierdut");
                        this.Close();
                    }
                    else
                    {
                        nr++;
                        int c=0;
                        if(i>1 && A.get(i-1, j)==1) c++;
                        if(i>1 && j>1 && A.get(i-1, j-1)==1) c++;
                        if(i<x && j<y && A.get(i+1, j+1)==1) c++;
                        if(j>1 && A.get(i, j-1)==1) c++;
                        if(i<x && A.get(i+1, j)==1) c++;
                        if(j<y && A.get(i, j+1)==1) c++;
                        if(i>1 && j<y && A.get(i-1, j+1)==1) c++;
                        if(i<x && j>1 && A.get(i+1, j-1)==1) c++;
                        b.Text=Convert.ToString(c);
                        if(nr==x*y-z)
                        {
                            MessageBox.Show("Ai castigat");
                            this.Close();
                        }
                    }
                }
        }

            private void label1_Click(object sender, EventArgs e)
            {

            }

            private void label2_Click(object sender, EventArgs e)
            {

            }
    }
}
