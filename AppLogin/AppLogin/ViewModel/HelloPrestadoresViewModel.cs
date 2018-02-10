using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Model;
using System.Windows.Input;
using AppLogin.Services;
using Xamarin.Forms;

namespace AppLogin.ViewModel
{
    public class HelloPrestadoresViewModel: ViewModelBase 
    {
        DataService service = new DataService();
                ObservableCollection<Tecnico> monkeys;


        public Image beachImage;

        public Image BeachImage 
        {
            get { return beachImage; }

            set {
              
                beachImage = value;
            }

        }

        public ObservableCollection<Tecnico> Monkeys
        {
            get { return monkeys; }
            set
            {
               
                monkeys = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadMonkeysCommand { get; set; }


        public HelloPrestadoresViewModel(Tecnico message): base("Onde estão os Tecnicos!?")
        {
             
            Monkeys = new ObservableCollection<Tecnico>();
            var beachImages = new Image { Aspect = Aspect.AspectFit };
            beachImages.Source = ImageSource.FromFile("monkeys.png");
            this.BeachImage = beachImages; 


            if (Loading) return;
            Loading = true;
            Carregar();
            Loading = false;
        }

        private async void Carregar()
        {
          

            var data = await  service.GetListaAsync();

            this.Monkeys.Clear();
             Monkeys = new ObservableCollection<Tecnico>(data);
            

          
        }
    }
}
