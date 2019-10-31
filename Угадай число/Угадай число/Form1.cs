using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Угадай_число
{
    public partial class Form1 : Form
    {
        int x = 0;
        int min = 0, max = 2000;

        public Form1()
        {
            InitializeComponent();
            MessageBoxManager.Cancel = "Больше";
            MessageBoxManager.Yes = "Меньше";
            MessageBoxManager.No = "Равно";
            MessageBoxManager.Register();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            do
            {
                x = (max - min) / 2+min;
                result = MessageBox.Show($"Max= {max}, min={min}\n\tЗагаданное число меньше/равно/больше {x}? ", "Давай разгадаем", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    max = x;
                }
                if (result == DialogResult.Cancel)
                    min = x;

            } while (result != DialogResult.No&&max!=min&&min<max);
            if (result == DialogResult.No)
            {
                MessageBox.Show($"Загаданное вами число {x}", "Поздравляем!!!");
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                MessageBox.Show("Вы забыли свое число", "Упс!!!");
                System.Threading.Thread.Sleep(1000);
            }
            Application.Exit();
        }
    }
}
