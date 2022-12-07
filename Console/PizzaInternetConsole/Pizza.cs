using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaInternetConsole
{
        public class Pizza
        {
            //private : only inside class, protected available in class and child,  public available in main,
            private string nom;
            private int prix;
            private string[] ingredients;
            private bool vegetarienne;

            public Pizza(string nom, int prix, string[] ingredients, bool vegetarienne)
            {
                this.nom = nom;
                this.prix = prix;
                this.ingredients = ingredients;
                this.vegetarienne = vegetarienne;
            }
            virtual public void AfficherPizza()
            {
                string isVege = vegetarienne ? " (V) " : "";
                //if (vegetarienne)
                //{
                //    isVege = "(V)";
                //}

            Console.WriteLine("Pizza : " + nom + isVege+ "- . Prix : " + prix + " USD.");
            Console.WriteLine(String.Join(", ", ingredients));
               
            Console.WriteLine("");
            }
            public int GetPrix()
            {
                return prix;
            }
            public int Prix
            {
                get { return prix; }
            }
        public string Nom
            {
                get { return nom; }
            }
        }
}
