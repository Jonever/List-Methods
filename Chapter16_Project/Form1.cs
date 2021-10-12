using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter16_Project
{
    public partial class Form1 : Form
    {
        Data <string> data;

        public Form1()
        {
            InitializeComponent();
            data = new Data<string>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string info = textBox1.Text;
            int find = data.IndexOf(info);
            if (find == -1)
            {
                if (info != "")
                {
                    data.Add(info);
                    ShowInfo();
                }
            }
            else
            {
                MessageBox.Show("Entry is already exist");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string info = textBox1.Text;
            int remove = data.Remove(info);
            if (remove > -1)
            {
                ShowInfo();
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Element not found!");
            }
        }
        private void ShowInfo()
        {
            richTextBox1.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            for (int i = 0; i < data.Count; i++)
            {
                richTextBox1.AppendText(data[i] + "\r\n");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string info = textBox2.Text;
            string index = textBox3.Text;
            int index_ = -1;
            try
            {
                index_ = Convert.ToInt32(index);
            }
            catch { }

            int find = data.IndexOf(info);
            if (find == -1)
            {
                data.Insert(index_, info);
                ShowInfo();
            }
            else
            {
                MessageBox.Show("Entry is already exist");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            data.Clear();
            ShowInfo();
        }
    }

}
  
