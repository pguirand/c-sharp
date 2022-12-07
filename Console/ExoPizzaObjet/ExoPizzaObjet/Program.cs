using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ExoPizzaObjet
{
    internal class Program
    {
        class Pizza
        {
            private static string LastPizzaName; // Utilisation seulement en interne
            private static Pizza LastPizza; // passer directement par l'objet Pizza

            private static Pizza LessExpensivePizza;
            private static Pizza MoreExpensivePizza;

            //private : only inside class, protected available in class and child,  public available in main,
            protected string nom;
            int prix;
            protected string[] ingredients;

            public Pizza(string nom, int prix, string[] ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.ingredients = ingredients;
                //LastPizzaName = nom;
                LastPizza = this;

                if (LessExpensivePizza == null)
                {
                    LessExpensivePizza = this;
                } else
                {
                    if (prix < LessExpensivePizza.prix)
                    {
                        LessExpensivePizza = this;
                    }
                }
                if (MoreExpensivePizza == null)
                {
                    MoreExpensivePizza = this;
                } else
                {
                    if (prix > MoreExpensivePizza.prix)
                    {
                        MoreExpensivePizza = this;
                    }
                }
            }
            virtual public void AfficherPizza()
            {
                Console.WriteLine("Pizza : " + nom + ". Prix : " + prix+" USD.");
                Console.WriteLine(String.Join(", ", ingredients));
                Console.WriteLine("");
            }
            public int GetPrix()
            {
                return prix;
            }

            
            public int Prix
            {
                get { return prix; }   // Lecture seule 
                set {
                    //prix = value;
                    Console.WriteLine("ERREUR : Modification de pizza interdite! " + value);
                    }
            }
            public static void DisplayLastPizza()
            {
                if (LastPizza == null)
                {
                    Console.WriteLine("Aucune pizza n'est encore crée.");
                } else
                {
                    Console.WriteLine("** DERNIERE PIZZA**");
                    //Console.WriteLine("Derniere Pizza crée : " + LastPizzaName);
                    LastPizza.AfficherPizza();
                }
            }
            public static void LessMoreExpensivePizzas()
            {
                if (LessExpensivePizza != null)
                {
                    Console.WriteLine("** PIZZA MOINS CHERE **");
                    LessExpensivePizza.AfficherPizza();
                }
                if (MoreExpensivePizza != null)
                {
                    Console.WriteLine("** PIZZA MOINS CHERE **");
                    MoreExpensivePizza.AfficherPizza();
                }
            }
        }
        class PizzaGratuite:Pizza
        {
            public PizzaGratuite(string nom, string[] ingredients) : base(nom, 0, ingredients)
            {

            }
            override public void AfficherPizza()
            {
                Console.WriteLine("Pizza : " + nom + " - GRATUIT.");
                Console.WriteLine(String.Join(", ", ingredients));
                Console.WriteLine("");
            }

        }

        static void Main(string[] args)
        {

            List<Pizza> pizzaList = new List<Pizza>();
            pizzaList.Add(new Pizza("Bacon", 12, new string[] {"Bacon", "Champignons", "Tomates", "Oignons"}));
            pizzaList.Add(new Pizza("Hawaii", 9, new string[] { "Ananas", "Poivrons", "Tomates", "Oignons" }));
            pizzaList.Add(new Pizza("Griot", 13, new string[] { "Porc", "Ail", "Tomates", "Oignons" }));
            pizzaList.Add(new Pizza("Vegetarienne", 10, new string[] { "Brocolli", "Tomates", "Oignons" }));
            pizzaList.Add(new Pizza("Kebab", 14, new string[] { "Kebab", "Champignons", "Tomates", "Poivrons" }));
            pizzaList.Add(new PizzaGratuite("Hareng", new string[] { "Hareng" }));

            pizzaList[0].Prix = 100; // Methode Set 
            pizzaList.Sort((Pizza x, Pizza y) =>
            {
                //mettre les variables string et nom en public pour acceder. mais pas conseille !!
                // Creer une fonction Getprix() pour retourner un prix
                // Ou encore passer par une propriete Prix
                //return x.prix.CompareTo(y.prix); 
                //return x.GetPrix().CompareTo(y.GetPrix());
                return x.Prix.CompareTo(y.Prix);


            });

            foreach (Pizza pizza in pizzaList)
            {
                pizza.AfficherPizza();
            }
            Pizza.DisplayLastPizza();
            Pizza.LessMoreExpensivePizzas();



        }

    }
}
