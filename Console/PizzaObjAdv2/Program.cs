namespace PizzaObjAdv2
{
    internal class Program
    {
        class Pizza
        {
            protected string nom;
            int prix;
            protected string[] ingredients;


            private static Pizza dernierePizzaCree;
            private static Pizza LessExpensivePizza;
            private static Pizza MostExpensivePizza;




            public Pizza(string nom, int prix, string[] ingredients)
            {
                this.nom = nom;
                this.prix = prix;
                this.ingredients = ingredients;

                dernierePizzaCree = this;

                if (LessExpensivePizza == null)
                {
                    LessExpensivePizza = this;
                }
                else
                {
                    if (prix < LessExpensivePizza.Prix)
                    {
                        LessExpensivePizza = this;
                    }
                }
                if (MostExpensivePizza == null)
                {
                    MostExpensivePizza = this;
                }
                else
                {
                    if (prix > MostExpensivePizza.Prix)
                    {
                        MostExpensivePizza = this;
                    }
                }
            }

            public int Prix
            {
                get { return prix; }

                set
                {
                    //prix = value;
                    Console.WriteLine("ERREUR, impossible modifier prix " + value);
                }
            }

            public static void AfficherDernierePizza()
            {
                if (dernierePizzaCree == null)
                {
                    Console.WriteLine("Pas de pizzas crees");
                }
                else
                {
                    Console.WriteLine("** DERNIERE PIZZA CREE **");
                    dernierePizzaCree.AfficherPizza();
                }

            }
            public static void AfficherMoreandLessExpPizza()
            {
                if (LessExpensivePizza != null)
                {
                    Console.WriteLine("** PIZZA LA MOINS CHERE **");
                    LessExpensivePizza.AfficherPizza();
                }
                if (MostExpensivePizza != null)
                {
                    Console.WriteLine("** PIZZA LA PLUS CHERE **");
                    MostExpensivePizza.AfficherPizza();
                }

            }

            virtual public void AfficherPizza()
            {
                Console.WriteLine("Pizza : " + nom + " - " + prix + " USD");
                Console.WriteLine(string.Join(", ", ingredients));
            }
        }

        class PizzaGratuite : Pizza
        {
            public PizzaGratuite(string nom, string[] ingredients) : base(nom, 0, ingredients)
            {

            }
            override public void AfficherPizza()
            {
                Console.WriteLine("Pizza : " + nom + " - GRATUIT ");
                Console.WriteLine(string.Join(", ", ingredients));
            }
        }
        static void Main(string[] args)
        {
            //Pizza mapizza = new Pizza("4 fromages", 11);
            List<Pizza> pizzas = new List<Pizza>();
            pizzas.Add(new Pizza("4 fromages", 11, new string[] { "Mozarella", "Oignons", "Tomates", "Ail" }));
            pizzas.Add(new Pizza("Peperonni ", 10, new string[] { "Peperonni", "Tomates", "Poivron" }));
            pizzas.Add(new Pizza("Griot", 13, new string[] { "Tomates", "Porc", "Olives", "Champignons" }));
            pizzas.Add(new Pizza("Vegetarienne", 9, new string[] { "Tomates", "Oignons", "Tomates", "Olives" }));
            pizzas.Add(new Pizza("Lakay", 12, new string[] { "Poulet", "Oignons", "Tomates", "Ail" }));
            pizzas.Add(new PizzaGratuite("Special", new string[] { "Oignons", "Tomates", "Mozarella" }));

            //pizzas[0].prix = 150;
            pizzas[0].Prix = 120;
            pizzas.Sort((Pizza x, Pizza y) =>
            {
                return x.Prix.CompareTo(y.Prix);
            });

            foreach (Pizza p in pizzas)
            {
                p.AfficherPizza();
            }

            Pizza.AfficherDernierePizza();

            Pizza.AfficherMoreandLessExpPizza();
            //mapizza.AfficherPizza();
        }
    }
}