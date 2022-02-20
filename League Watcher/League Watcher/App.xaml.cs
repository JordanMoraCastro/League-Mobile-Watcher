using League_Watcher.Services;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Key_Finder
{
    public partial class App : Application
    {

        public App()
        {

            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()); //Navegacion en Pila
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
