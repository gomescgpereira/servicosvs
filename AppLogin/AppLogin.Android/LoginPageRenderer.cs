using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Auth;
using Newtonsoft.Json.Linq;
using AppLogin;
using Xamarin.Forms;
using Android.App;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using AppLogin.Model;
using AppLogin.Services;
using Plugin.Geolocator;

[assembly: ExportRenderer(typeof (Login) , typeof(AppLogin.Droid.LoginPageRenderer))]
namespace AppLogin.Droid
{
    public class LoginPageRenderer : PageRenderer
    {
        double latitude = 0;
        double longitude = 0;
        public Tecnico tecnico;
        public LoginPageRenderer()
        {
            var activity = this.Context as Activity;
            var auth = new OAuth2Authenticator(
                clientId: "276078866188624",
                scope: "email",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("http://www.facebook.com/connect/login_success.html"));
              
        auth.Completed +=  async (sender, eventArgs) =>
            {
              //  DismissViewController(true, null);
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var expiresIn = Convert.ToDouble(eventArgs.Account.Properties["expires_in"]);
                    var expirDate= DateTime.Now + TimeSpan.FromSeconds(expiresIn);

                    var request = new OAuth2Request("GET", new Uri("https://graph.facebook.com/me?fields=id,name,email"), null, eventArgs.Account);
                    var response = await request.GetResponseAsync();
                    var obj = JObject.Parse(response.GetResponseText());
                    tecnico = new Tecnico();

                    var id = obj["id"].ToString().Replace("\"","");
                    tecnico.Nome  = obj["name"].ToString().Replace("\"", "");
                    tecnico.Email = obj["email"].ToString().Replace("\"", "");
                    tecnico.Token = id;
                    await GetTecnicoAsync();
                    tecnico.Lat = latitude;
                    tecnico.Lng = longitude;

                    await PostTecnicoAsync(tecnico);


                 
                  //App.NavigateToProfile(string.Format("Olá {0} - {1}", name,id));
                    App.NavigateToProfile(tecnico);

                    // Use eventArgs.Account to do wonderful things
                } else
                {
                   // App.NavigateToProfile("Usuario Cancelouo Login");
                }
            };
            activity.StartActivity(auth.GetUI(activity));
        }

        private async Task GetTecnicoAsync()
        {
             
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 50;

                var position = await locator.GetPositionAsync(timeout: System.TimeSpan.FromSeconds(100000));

                latitude = position.Latitude;
                longitude = position.Longitude;

            }

            catch (Exception ex)
            {

            }
        }
    

        private void DismissViewController(bool v, object p)
        {
            throw new NotImplementedException();
        }

        public async Task PostTecnicoAsync(Tecnico tecnico)
        {
            DataService service = new DataService();

            int existe = await service.ExisteTecnicoAsync(tecnico);

            if (existe == 0)
            { 

            await service.AddTecnicoAsync(tecnico);
            }
             else
            {
                tecnico.Id = existe;
               // await service.UpdateTecnicoAsync(tecnico);
            }
        }
    }
}