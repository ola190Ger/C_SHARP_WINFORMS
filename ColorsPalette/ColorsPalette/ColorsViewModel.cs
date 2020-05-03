using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorsPalette
{
    class ColorsViewModel : INotifyPropertyChanged
    {
        private ColorModel selectedClr;

        public ObservableCollection<ColorModel> colorModels { get; set; }
        public ColorModel SelectedClr
        {
            get { return selectedClr; }
            set
            {
                if (selectedClr != value)
                {
                    selectedClr = value;
                    OnPropertyChanged("SelectedClr");
                }

            }
        }

        public ColorsViewModel()
        {
            SelectedClr = new ColorModel();
            colorModels = new ObservableCollection<ColorModel> {
                new ColorModel { R=255, A=255, B=0, G=0, Clr=new SolidColorBrush(Color.FromArgb((byte)255, (byte)255, (byte)0, (byte)0))  }
            };
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      ColorModel color = new ColorModel();
                      colorModels.Insert(0, SelectedClr);
                      SelectedClr = color;
                  }));
            }
        }

        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      ColorModel color = obj as ColorModel;
                      if (color != null)
                      {
                          colorModels.Remove(color);
                      }
                  },
                 (obj) => SelectedClr != null));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
