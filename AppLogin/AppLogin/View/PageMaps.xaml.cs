using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using AppLogin.Model;
using AppLogin.Services;

namespace AppLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageMaps : ContentPage
    {

        DataService service = new DataService();
        public PageMaps()
        {
            InitializeComponent();
           
        }

        protected override  void OnAppearing()
        {
            base.OnAppearing();

            MainMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(-22.91, -43.24), Distance.FromKilometers(20)));

            CarregarTecnico();
           




        }

        private async void CarregarTecnico()
        {

            List<Tecnico> data = await service.GetListaAsync();

            int count = 0;
            foreach (Tecnico elemento in data)
            {
                count += 1;
                var pin = new PinHerdado();
                pin.Position = new Position(elemento.Lat, elemento.Lng);
                pin.Label = "Posição#" + count.ToString();
                pin.Address = "Endereço#" + count.ToString();
                pin.tecnico = elemento;

                pin.Clicked += Pin_Clicked;

                MainMap.Pins.Add(pin);



            }
        }   
       

    private async void Pin_Clicked(object sender, EventArgs e)
        {
            var SelectedPin = sender as PinHerdado;
            DisplayAlert(SelectedPin?.Label, SelectedPin?.tecnico.Nome, "Ok");

            await App.Current.MainPage.Navigation.PushAsync(new IncludeSolicitante(SelectedPin));
          
        }
    }
}