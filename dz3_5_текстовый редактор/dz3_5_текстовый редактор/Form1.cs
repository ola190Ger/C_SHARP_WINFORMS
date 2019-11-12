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
        string highlighted_text;
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
            Text = ofd.FileName;
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
            NewTxt();

        }
         private void NewTxt()
        {
            if (textBox1.Text.Length > 0)
            {
                DialogResult rez = MessageBox.Show("Сохранить данные?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rez == DialogResult.Yes)
                {
                    SaveTxt();
                }
            }
            textBox1.Text = "";

        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            NewTxt();
        }

        private void ВыделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //textBox1.Select();
        }

        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void КопироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void ToolStripButton5_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void ВырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void ToolStripButton6_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void ВставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void ОтменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();
        }

        private void ШрифтToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if(fd.ShowDialog()==DialogResult.OK)
            {
                textBox1.Font = fd.Font;
            }
        }

        private void ШрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fd.Font;
            }

        }

        private void ЦветФонаToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = fd.Color;
            }

        }

        private void ЦветФонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = fd.Color;
            }

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = fd.Color;
            }

        }

        private void ЦветФонаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog fd = new ColorDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                
                textBox1.ForeColor = fd.Color;
            }

        }

    }
}
