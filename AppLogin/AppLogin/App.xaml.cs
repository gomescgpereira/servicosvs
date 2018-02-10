using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppLogin.Model;
using AppLogin.View;

namespace AppLogin
{
    public partial class App : Application
    {
        public App()
        {
           

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        public static Action HideLoginView
        {
            get
            {
                return new Action(() => App.Current.MainPage.Navigation.PopModalAsync());
            }
        }

        public async static Task NavigateToProfile(Tecnico message)
        {
            //await App.Current.MainPage.Navigation.PushAsync(new Profile(message));
          // await App.Current.MainPage.Navigation.PushAsync(new HelloPrestador(message));

           await App.Current.MainPage.Navigation.PushAsync(new PageMaps());


        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
