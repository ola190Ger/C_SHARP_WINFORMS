using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz3_3_SalePc
{
    public partial class Form2 : Form
    {

        private AddDelegate add_deleg;
        private EditDelegate edit_deleg;

        Components NewComp = new Components();

        int ind;
        string textitemind;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 f1, AddDelegate add_Delegate, EditDelegate edit_delegate)
        {
            InitializeComponent();
            //создание листбокса для редактирования и добавления
            foreach (Components cp in f1.components_list)
                listBox1.Items.Add($"{cp.name} {cp.price}");
            //присвоение значения делегатам
            this.add_deleg = add_Delegate;
            this.edit_deleg = edit_delegate;

        }

        private void Button1_Click(object sender, EventArgs e)//добавление
        {
            button2.Enabled = false;
            label1.Text = "Введите название и цену."; label1.Visible = true;
            textBox1.Visible = true; textBox2.Visible = true;
            button3.Visible = true; button3.Enabled = true;
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

        private void Button3_Click(object sender, EventArgs e)//в зависимости от того какая кнопка нажата создает новый объект и добав/редакт его
        {
            if(textBox1.Text!=""||textBox2.Text!="")
            {
                NewComp.name = textBox1.Text; NewComp.price = int.Parse(textBox2.Text);
            }
            else
            {
                MessageBox.Show("Введите данные.");
            }
            if (button1.Enabled)
            {
                add_deleg(NewComp);
                listBox1.Items.Add($"{NewComp.name} {NewComp.price}");
                MessageBox.Show("Компонент добавлен.");
                
            }
            if(button2.Enabled)
            {
                edit_deleg(NewComp, ind);
                listBox1.Items[ind] = ($"{NewComp.name} {NewComp.price}");
                MessageBox.Show("Компонент изменен.");
            }
            textBox1.ResetText(); textBox2.ResetText();
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            label1.Text = "Введите новые название и цену."; label1.Visible = true;
            textBox1.Visible = true; textBox2.Visible = true;
            button3.Visible = true; button3.Enabled = true;
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)//передает данные в текст боксы
        {
            int price ;
            if(listBox1.SelectedIndex!=-1)
            {
                ind = listBox1.SelectedIndex;
                textitemind = listBox1.Items[ind].ToString();

                textBox1.Text = string.Join("",textitemind.Where(c=>char.IsLetter(c)));
                int.TryParse(string.Join("", textitemind.Where(c => char.IsDigit(c))), out price);
                textBox2.Text = price.ToString();
            }
        }


    }
}
