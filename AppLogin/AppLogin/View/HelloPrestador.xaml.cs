using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppLogin.ViewModel;
using AppLogin.Model;

namespace AppLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HelloPrestador : ContentPage
    {
        public HelloPrestador(Tecnico message)
        {
            InitializeComponent();
            BindingContext =  new HelloPrestadoresViewModel(message);
        }
    }
}