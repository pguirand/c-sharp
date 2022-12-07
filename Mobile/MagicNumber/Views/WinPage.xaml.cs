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
    public partial class WinPage : ContentPage
    {
        public WinPage() : this(5)
        {

        }
        public WinPage(int nombremagique)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            mainLayout.Scale = 0.7;
            mainLayout.ScaleTo(1.0, 1500, Easing.BounceIn);
            magicNumberLabel.Text = "Le nombre magique était bien : " + nombremagique;
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            NavigateBacktoWelcomePage();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task NavigateBacktoWelcomePage()
        {
            await Task.Delay(3000);
            await Navigation.PopToRootAsync();
        }
    }
}