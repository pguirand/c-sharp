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
    public partial class GamePage : ContentPage
    {
        const int NB_MAGIQUE_MIN = 1;
        const int NB_MAGIQUE_MAX = 5;
        int nombreMagique  = 0;
        public GamePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            nombreMagique = new Random().Next(NB_MAGIQUE_MIN, NB_MAGIQUE_MAX);
            minmaxLabel.Text = "Entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX;
        }

        private void ButtonClick(object sender, EventArgs e)
        {

            if (String.IsNullOrWhiteSpace(NumberEntry.Text))
            {
                DisplayAlert("ERREUR", "Vous devez entrer un nombre", "OK");
                return;
            }

            int nbutilisateur = 0;

            try
            {
                nbutilisateur = Int32.Parse(NumberEntry.Text);
            }
            catch (Exception)
            {
                DisplayAlert("ERREUR", "Vous devez entrer uniquement des chiffres", "OK");
                return ;
            }



            if ((nbutilisateur < NB_MAGIQUE_MIN) || (nbutilisateur > NB_MAGIQUE_MAX))
            {
                DisplayAlert("ERREUR", "Vous devez entrer un nombre entre " + NB_MAGIQUE_MIN + " et " + NB_MAGIQUE_MAX, "OK");
                return;
            }

            if (nombreMagique > nbutilisateur)
            {
                DisplayAlert("Oops", "Le nombre magique est superieur a " + nbutilisateur, "OK");
                NumberEntry.Text = "";
                return;
            }
            if (nombreMagique < nbutilisateur)
            {
                DisplayAlert("Oops", "Le nombre magique est inférieur a " + nbutilisateur, "OK");
                NumberEntry.Text = "";
                return;
            }
            if (nombreMagique == nbutilisateur)
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                WinAction();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                return;
            }
        }
        private async Task WinAction()
        {
            //await DisplayAlert("Gagné ", "Vous avez trouve le nombre magique ", "OK");
            //await this.Navigation.PopAsync();
            await Navigation.PushAsync(new WinPage(nombreMagique));
        }
    }
}