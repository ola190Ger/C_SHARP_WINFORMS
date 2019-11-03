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
        string[] filesName;
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

                /*
                for(int i=0; i<files.Length; i++)
                    filesName[i]=Path.GetFileName(files[i]);
                    */
                //listBox1.Items.AddRange(filesName);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            

            foreach (string str in files)
            {
               
                    listBox1.Items.Add(Path.GetFileName(str));
            }
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add($"{label1.Text}_{textBox1.Text} ничего не найдено");
        }
    }
}
