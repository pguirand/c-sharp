using MagicNumber.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagicNumber
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
            //MainPage = new WinPage();

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
