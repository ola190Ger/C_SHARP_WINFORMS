using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz3_7_SubItem
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            textBox1.ForeColor = Color.Black;
        }

        private void TextBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Введите название пункта меню.", "Отсутствует имя");
            else
                menuStrip1.Items.Add(new ToolStripMenuItem(textBox1.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")// проверка введено ли назв для нового подменю
                MessageBox.Show("Введите название подпункта меню.", "Отсутствует имя");
            else
            {

                if (menuStrip1.Items.Count == 0)// если меню не создано
                    MessageBox.Show(" Подменю не может быть добавлено. Введите имя меню и только потом подменю");
                else
                    if (menuStrip1.Items.Count == 1)//если есть только 1н пункт меню
                    {
                    (menuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(textBox2.Text);
                    }
                else //если пунктов меню несколько
                {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Введите название меню, в которое надо добавить подиеню.", "Куда добавлять?", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        foreach(ToolStripMenuItem menuItem in menuStrip1.Items)
                        {
                            if(menuItem.Text==textBox1.Text)
                            {
                                menuItem.DropDownItems.Add(textBox2.Text);
                            }
                        }
                    }
                }

            }
        }
    }
}
