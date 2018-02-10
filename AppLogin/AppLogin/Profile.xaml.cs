using AppLogin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLogin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        public Profile(Tecnico message)
        {
            InitializeComponent();
            this.lblMessage.Text = message.Nome.ToString();
        }
    }
}