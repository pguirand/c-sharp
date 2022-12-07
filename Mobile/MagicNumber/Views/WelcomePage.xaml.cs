using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MagicNumber.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //InfiniteRotation(star1, 2000);
            //InfiniteRotation(star2, 5000);
            //InfiniteRotation(star3, 9000);
            InfiniteScale(PlayButton, 1000);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed


        }


        private async Task InfiniteScale(View view, uint length)
        {
            bool always = true;
            while (always)
            {
                await view.ScaleTo(1.1, length);
                await view.ScaleTo(1.0, length);
            }
        }

        private void PlayButtonClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamePage());
        }
    }
}