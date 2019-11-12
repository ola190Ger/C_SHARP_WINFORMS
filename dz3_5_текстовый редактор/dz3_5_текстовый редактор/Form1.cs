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

namespace dz3_5_текстовый_редактор
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            OpenTxt();
        }

        private void OpenTxt()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text fales(*.txt)|*.txt|All files(*.*)|*.*";
            if(ofd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Lines = File.ReadAllLines(ofd.FileName);
            }
        }

        private void ОткрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTxt();
        }

        private void ToolStripButton3_Click(object sender, EventArgs e)
        {
            SaveTxt();
        }
        private void SaveTxt()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text fales(*.txt)|*.txt|All files(*.*)|*.*";
            if (sfd.ShowDialog()==DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void СохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTxt();
        }

        private void СохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveTxt();
        }

        private void НовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //что делать если какойто текст уже есть
            textBox1.Text = "";
        }
    }
}
