using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLogin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.btnLogar.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new Login());
            };
        }
    }
}
