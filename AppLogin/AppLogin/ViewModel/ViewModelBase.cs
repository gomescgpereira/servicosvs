using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AppLogin.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public bool busy;
        public string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public bool Busy
        {
            get { return busy; }
            set
            {
                busy = value;
                OnPropertyChanged();
            }
        }

        bool loading;
        public bool Loading
        {
            get { return loading; }
            set
            {
                loading = value;
                OnPropertyChanged();
            }
        }

        public ViewModelBase(string title)
        {
            this.Title = title;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }





    }
}


