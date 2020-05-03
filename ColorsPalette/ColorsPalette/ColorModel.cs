using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorsPalette
{
    public class ColorModel: INotifyPropertyChanged
    {
        private double r;
        public double g;
        public double b;
        public double a;
        public SolidColorBrush clr;
        

        public double R
        {
            get => r;
            set
            {
                if (r != value)
                {
                    r = value; OnPropertyChanged("R"); OnPropertyChanged("Clr");
                }
            }

        }

        public double G
        {
            get => g;
            set
            {
                if (g != value)
                {
                    g = value; OnPropertyChanged("G"); OnPropertyChanged("Clr");
                }
            }
        }

        public double B
        {
            get => b;
            set
            {
                if (b != value)
                {
                    b = value; OnPropertyChanged("B"); OnPropertyChanged("Clr");
                }
            }

        }

        public double A
        {
            get => a;
            set
            {
                if (a != value)
                {
                    a = value; OnPropertyChanged("A"); OnPropertyChanged("Clr");
                }
            }

        }

        public SolidColorBrush Clr
        {
            set
            {
                if (clr != value)
                {
                    clr = value; OnPropertyChanged("Clr");
                }
            }
            get
            {
                clr = new SolidColorBrush(Color.FromArgb((byte)A, (byte)R, (byte)G, (byte)B));
                return clr;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


    }
}
