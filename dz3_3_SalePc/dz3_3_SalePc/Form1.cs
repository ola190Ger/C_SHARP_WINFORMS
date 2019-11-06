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


    public delegate void AddDelegate(Components cp);//делегат ф-ции для добавления компонента
    public delegate void EditDelegate(Components cp, int ind);//делегат ф-ции для изменения компонента

    public partial class Form1 : Form
    {
        public List<Components> components_list = new List<Components>
        {
                new Components { name = "Mather Board", price = 1250 },
                new Components { name = "Processor", price = 4500 },
                new Components { name = "Video Card", price = 800 },
                new Components { name = "HDD", price = 300 },
                new Components { name = "SDD", price = 450 },
                new Components { name = "Ram", price = 200 }
        };
        Components SelectedComp;

        int total = 0;//общая сумма покупки
        public Form1()
        {
            InitializeComponent();

            UpladCombobox();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedComp = (Components)comboBox1.SelectedItem;// выбраный в комбобокс
            if (SelectedComp != null)
                textBox1.Text = SelectedComp.price.ToString();
        }

        private void Button1_Click(object sender, EventArgs e)//добавление в корзину
        {
            total += SelectedComp.price;
            listBox1.Items.Add($"{SelectedComp.name} - {SelectedComp.price.ToString()}");
            label2.Text = $"Сумма: {total.ToString()} грн.";
        }

        private void Button2_Click(object sender, EventArgs e)//покупка
        {
            MessageBox.Show("Заказ оформлен..");
            listBox1.Items.Clear();
            label2.Text = "Сумма: 0 грн.";
            total = 0;
        }

        private void Button3_Click(object sender, EventArgs e)//вызов второй формы для редактирования и добавл
        {
            Form2 form2 = new Form2(this, AddList, EditList);
            form2.Show();
        }

        public void AddList(Components cp)//делегируемая ф-ция во вторую форму
        {
            components_list.Add(cp);
            UpladCombobox();
        }

        public void EditList(Components cp, int ind)//делегируемая ф-ция во вторую форму
        {
            components_list[ind] = cp;
            UpladCombobox();
        }

        private void UpladCombobox()// обновление комбобокс 
        {
            comboBox1.DataSource = null;
            comboBox1.DataSource = components_list;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "price";
        }





    }

    public class Components
    {
       public string name { set; get;}
       public int price { set; get;}
    }
}
