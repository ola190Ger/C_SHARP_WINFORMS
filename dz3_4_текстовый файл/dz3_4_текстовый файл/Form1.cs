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

namespace dz3_4_текстовый_файл
{
    public delegate void ReturnText(string[] str);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                string filename = openFile.FileName;
                textBox1.Lines=(File.ReadAllLines(filename));
                button2.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(textBox1.Lines, Returntxt);
            f2.Show();
        }

        public void Returntxt(string[] str)
        {
            textBox1.Lines = str;
        }
    }
}
