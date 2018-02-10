using AppLogin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogin.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppLogin.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IncludeSolicitante : ContentPage
    {
        DataSeviceSolicitante service = new DataSeviceSolicitante();
        public PinHerdado dado;
        public IncludeSolicitante(PinHerdado message)
        {
            InitializeComponent();

            this.dado = message;

            
            txtNome.Text = message.tecnico.Nome.ToString();
            txtemail.Text = message.tecnico.Email.ToString();
            txtposicao.Text = message.Position.Latitude.ToString();

            btnSalvar.Clicked += BtnSalvar_Clicked;
            


        }

        private async void BtnSalvar_Clicked(object sender, EventArgs e)
        {

            Solicitante solicita = new Solicitante();

            solicita.Clientid = 1;
            solicita.Prestadorid = dado.tecnico.Id;
            solicita.Inicio = System.DateTime.Now;
            solicita.Descricao = this.txtdescricao.Text;
            solicita.Status = "A";
            solicita.Lat = dado.Position.Latitude;
            solicita.Lng = dado.Position.Longitude;

            await service.AddTecnicoAsync(solicita);

          
        }

       
        
    }
}