using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {
        double price_hotDog=0;
        double price_burger=0;
        double price_fry=0;
        double price_cola=0;

         double summa_oil = 0;
         double summa_cafe = 0;
         double total_day = 0;

        int timesleep, timesleep2;
        bool timeswitch=true;
        public Form1()
        {
            InitializeComponent();
            var path = System.IO.Path.GetFullPath("1111.jpg");
            pictureBox1.Image = Image.FromFile(path);

            notifyIcon1.Click += NotifyIcon1_Click;

            List<Oil> oil = new List<Oil>
            {
                new Oil{ name="A-95",price=27.02},
                new Oil{ name="A-92",price=26.55},
                new Oil{ name="Дизель",price=26.12},
                new Oil{ name="Газ",price=18.36},
            };
            comboBox1.DataSource = oil;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "price";
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;

            textBox3.TextChanged += TextBox3_TextChanged;


            checkBox1.CheckedChanged += new EventHandler(checkBoxes_CheckedChanged);
            checkBox2.CheckedChanged += new EventHandler(checkBoxes_CheckedChanged);
            checkBox3.CheckedChanged += new EventHandler(checkBoxes_CheckedChanged);
            checkBox4.CheckedChanged += new EventHandler(checkBoxes_CheckedChanged);

            timer1.Interval = 1000;
            timesleep = 10;
            timer1.Tick += Timer1_Tick;

            timer2.Interval = 1000;
            timesleep2 = 15;
            timer2.Tick += Timer2_Tick;
            timer2.Start();
            //toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
            weekDayToolStripMenuItem.Text = DateTime.Now.DayOfWeek.ToString();
           // toolStripDropDownButton2.Text = System.Globalization.CultureInfo.GetCultureInfo("ru-ru").DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek);
            //toolStripTextBox1.Text = DateTime.Now.DayOfWeek.ToString();

            trackBar1.Minimum = 0; trackBar1.Maximum = 255;
            trackBar2.Minimum = 0; trackBar2.Maximum = 255;
            trackBar3.Minimum = 0; trackBar3.Maximum = 255;

        }

        private void NotifyIcon1_Click(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Oil oill = (Oil)comboBox1.SelectedItem;
            textBox2.Text = oill.price.ToString();

        }

        private void checkBoxes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                price_hotDog = 25.00;
            else
                price_hotDog = 0;

            if (checkBox2.Checked)
                price_burger = 25.20;
            else
                price_burger = 0;

            if (checkBox3.Checked)
                price_fry = 18.50;
            else
                price_fry = 0;

            if (checkBox4.Checked)
                price_cola = 15.50;
            else
                price_cola = 0;


            textBox7.Text = price_hotDog.ToString();
            textBox8.Text = price_burger.ToString();
            textBox9.Text = price_fry.ToString();
            textBox10.Text = price_cola.ToString();

            LabelCafe();
        }

        void LabelCafe()
        {
            label12.Text = (price_hotDog * double.Parse(textBox11.Text) + price_burger * double.Parse(textBox12.Text) + price_fry * double.Parse(textBox13.Text) + price_cola * double.Parse(textBox14.Text)).ToString();
        }


        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            label11.Text = (double.Parse(textBox2.Text) * double.Parse(textBox3.Text)).ToString();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                radioButton2.Checked = false;
                textBox3.ReadOnly = false;
            }
            else
                textBox3.ReadOnly = true;
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                radioButton1.Checked = false;
                textBox4.ReadOnly = false;
            }
            else
                textBox4.ReadOnly = true;
        }

        private void TextBox4_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = (double.Parse(textBox4.Text) / double.Parse(textBox2.Text)).ToString();
            label11.Text = textBox4.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            LabelCafe();
            label13.Text = (double.Parse(label11.Text) + double.Parse(label12.Text)).ToString();
            summa_oil += double.Parse(label11.Text);
            summa_cafe += double.Parse(label12.Text);
            total_day = summa_oil + summa_cafe;

            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timesleep--;

            if(timesleep<=0)
            {
                timer1.Stop();
                NewClient();
                timesleep = 10;
            }
        }

        void NewClient()
        {

            DialogResult rezult = MessageBox.Show("Новый клиент?", "Работаем");
           if(rezult==DialogResult.OK)
           {
                textBox11.Text = "0";
                textBox12.Text = "0";
                textBox13.Text = "0";
                textBox14.Text = "0";

                textBox3.Text = "0";
                textBox4.Text = "0";

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;

                LabelCafe();
                label13.Text = (double.Parse(label11.Text) + double.Parse(label12.Text)).ToString();

            }
        }
        private void SaveDataDay()
        {        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rezExit = MessageBox.Show("Завершить рабочий день?", "Конец", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rezExit == DialogResult.Yes)
            {
                MessageBox.Show($"Выручка за день: {total_day} грн", "Закрытие дня");
                // сохранить куда нить данные за день и тд
            }
            if (rezExit == DialogResult.No)
            {
                e.Cancel=true;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(button1, "Подсчет общей суммы");
            t.SetToolTip(comboBox1, "Выберите тип топлива");
            t.SetToolTip(radioButton1, "Сколько литров");
            t.SetToolTip(radioButton2, "На какую сумму заправляемся");
            t.SetToolTip(checkBox1, "для выбора поставьте галочку и введите нужное количество");
            t.SetToolTip(checkBox2, "для выбора поставьте галочку и введите нужное количество");
            t.SetToolTip(checkBox3, "для выбора поставьте галочку и введите нужное количество");
            t.SetToolTip(checkBox4, "для выбора поставьте галочку и введите нужное количество");

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {
            timesleep2--;
            if(timesleep2<=0)
            {
                if (timeswitch)
                {
                    timer2.Stop();
                    toolStripStatusLabel1.Text = DateTime.Now.ToShortDateString();
                    timeswitch = false; timesleep2 = 15;
                    timer2.Start();
                }
                else
                {
                    timer2.Stop();
                    toolStripStatusLabel1.Text = DateTime.Now.ToShortTimeString();
                    timeswitch = true; timesleep2 = 15;
                    timer2.Start();
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true; panel1.Enabled = true;
        }

        void changeBackColor()
        {
            int r = trackBar1.Value; int g = trackBar2.Value; int b = trackBar3.Value;
            BackColor = Color.FromArgb(r, g, b);
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false; panel1.Enabled = false;
        }

        private void TrackBar_ValueChanged(object sender, EventArgs e)
        {
            changeBackColor();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if(this.WindowState==FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");

            System.ComponentModel.ComponentResourceManager resourceManager = new ComponentResourceManager(this.GetType());
            resourceManager.ApplyResources(this, "$this");
            foreach (Control c in this.Controls)
                resourceManager.ApplyResources(c, c.Name);

        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");

            System.ComponentModel.ComponentResourceManager resourceManager = new ComponentResourceManager(this.GetType());
            resourceManager.ApplyResources(this, "$this");
            foreach (Control c in this.Controls)
                resourceManager.ApplyResources(c, c.Name);
        }
    }
}

class Oil
{
    public string name { set; get; }
    public double price { set; get; }
}

