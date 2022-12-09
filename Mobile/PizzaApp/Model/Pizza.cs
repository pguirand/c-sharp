using PizzaApp.extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaApp.Model
{
    public class Pizza
    {
        public string nom { get; set; }
        //public string Titre { get { return StringExtensions.FirstCapitalLetter(nom); } }
        public string Titre { get { return nom.FirstCapitalLetter(); } }
        //public string imageurl { get; set; }
        public string imageurl { get; set; } = "https://codeavecjonathan.com/res/default_pizza.jpg";

        //public int prix { get; set; }
        public float prix { get; set; }

        public string[] ingredients { get; set; }
        public string PrixEuros { get { return "$ " + prix; } }
        public string IngredientStr { get { return String.Join(", ", ingredients); } }

        public Pizza()
        {

        }
    }
}
