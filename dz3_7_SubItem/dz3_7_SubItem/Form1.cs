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
            {
                //ToolStripMenuItem fileItem = new ToolStripMenuItem(textBox1.Text);

                //fileItem.DropDownItems.Add("Создать");
                //fileItem.DropDownItems.Add(new ToolStripMenuItem("Сохранить"));

                menuStrip1.Items.Add(new ToolStripMenuItem(textBox1.Text));


                ToolStripMenuItem aboutItem = new ToolStripMenuItem("О программе");
                menuStrip1.Items.Add(aboutItem);

                MessageBox.Show($"{menuStrip1.Items[1]}", "About program");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
                MessageBox.Show("Введите название подпункта меню.", "Отсутствует имя");
            else
            {
                //ToolStripMenuItem submenu = new ToolStripMenuItem(textBox2.Text);

                if (menuStrip1.Items.Count == 0)
                    MessageBox.Show(" Подменю не может быть добавлено. Введите имя меню и подменю");
                else
                    if (menuStrip1.Items.Count == 1)
                    {
                    (menuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(textBox2.Text);
                    }
                    

                else
                {
                    //(menuStrip1.Items[0] as ToolStripMenuItem).DropDownItems.Add(textBox2.Text);

                    //укажи имя меню для подменю
                }

            }
        }
    }
}
