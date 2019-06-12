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
using System.Diagnostics;

namespace Practice18
{
    public partial class Form1 : Form
    {
        private string id;
        private string name;
        private string grade = "";
        private string date;
        private string amount;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] grade = { "1th", "2th", "3th", "4th", "5th", "6th", "7th", "8th", "9th", "10th" };
            comboBox1.Items.AddRange(grade);    // item 배열 추가하기
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            string[] amount = { "$5", "$10", "$15", "$20", "$25", "$30", "$35", "$40" };
            comboBox2.Items.AddRange(amount);
            comboBox2.SelectedIndex = 0;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            date = string.Format("{0}/{1}/{2}", dt.Month, dt.Day, dt.Year);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            id = textBox1.Text;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            grade = comboBox1.Items[comboBox1.SelectedIndex].ToString();

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            name = textBox2.Text;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            amount = comboBox2.Items[comboBox2.SelectedIndex].ToString();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            StreamWriter save = new StreamWriter(@"D:\Winform.txt", true);
            save.WriteLine(id);
            save.WriteLine(name);
            save.WriteLine(grade);
            save.WriteLine(date);
            save.WriteLine(amount);
            save.Close();
            MessageBox.Show("Saved Form !");
            Process.Start(@"D:\Winform.txt");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
            dateTimePicker1.Value = DateTime.Today;
            comboBox2.SelectedIndex = 0;
            MessageBox.Show("Cleared Form !");
        }
    }
}
