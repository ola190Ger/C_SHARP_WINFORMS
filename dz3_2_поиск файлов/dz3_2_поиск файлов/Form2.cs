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

namespace dz3_2_поиск_файлов
{
    public partial class Form2 : Form
    {
        string[] files;
        public Form2()
        {
            InitializeComponent();
            label1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public Form2(Form1 f1)
        {
            InitializeComponent();
            f1.BackColor = Color.Gray;
            label1.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if(folderBrowser.ShowDialog()==DialogResult.OK&&!string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
            {
                label1.Text = folderBrowser.SelectedPath;
                files = Directory.GetFiles(folderBrowser.SelectedPath);
                textBox1.Text = "";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                listBox1.Items.AddRange(files);
            string searchstr = string.Join("", textBox1.Text.Where(c => char.IsLetterOrDigit(c)));

            foreach (string str in files)
            {
               if(str.IndexOf(searchstr)!=-1)
                    listBox1.Items.Add(Path.GetFileName(str));
            }
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add($"{label1.Text}_{textBox1.Text} ничего не найдено");
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }


        private void Button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
