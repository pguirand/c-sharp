using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PizzaInternetConsole
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //string pizzasJson = "[{\"nom\":\"Hawaii\",\"prix\":9,\"ingredients\":[\"Ananas\",\"Fromage\",\"ail\",\"oignons\"]},{\"nom\":\"Bacon\",\"prix\":9,\"ingredients\":[\"Bacon\",\"Peperonni\",\"ail\",\"Tomates\",\"oignons\"]},{\"nom\":\"Vegetarienne\",\"prix\":9,\"ingredients\":[\"Poivrons\",\"Mozarella\",\"ail\",\"oignons\",\"Tomates\"]},{\"nom\":\"Hawaii\",\"prix\":9,\"ingredients\":[\"Ananas\",\"Fromage\",\"ail\",\"oignons\"]},{\"nom\":\"Kebab\",\"prix\":9,\"ingredients\":[\"Kebab\",\"Tomates\",\"ail\",\"oignons\",\"Peperonni\"]}]";
            //List<Pizza> pizzaList = new List<Pizza>();

            //const string URL = "https://codeavecjonathan.com/res/pizzas1.json";
            const string URL = "https://drive.google.com/uc?export=download&id=1Ul6monBXCRXqDml5-_Yoe__nF_i0q6bo";
            //WebClient client = new WebClient();
            string pizzasJson = "";
            Console.Write("Telechargement...");
            using (var webclient = new WebClient())
            {
                webclient.Encoding = System.Text.Encoding.UTF8;
                try
                {
                    pizzasJson = webclient.DownloadString(URL);
                    Console.WriteLine(" OK");
                }
                catch (WebException ex)
                {
                    string message = ex.Message;
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        message = "Verifiez votre URL";
                    }
                    if (ex.Status == WebExceptionStatus.NameResolutionFailure)
                    {
                        message = "Verifiez votre Accès Réseau";
                    }
                    Console.WriteLine("ERREUR : "+ message);
                    return;
                }
            }
            Console.WriteLine("\n");

            //List<Pizza> pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzasJson);
            ContenuJson contenuJson = JsonConvert.DeserializeObject<ContenuJson>(pizzasJson);
            List<Pizza> pizzas = contenuJson.pizzas;

            //sort

            if (contenuJson.reglages.tri.Equals("prix"))
            {
                pizzas.Sort((p1, p2) => { return p2.Prix.CompareTo(p1.Prix); });  //reverse order price
            } else if (contenuJson.reglages.tri.Equals("nom"))
            {
                pizzas.Sort((n1, n2) => { return n1.Nom.CompareTo(n2.Nom); });
            }

            foreach (Pizza pizza in pizzas)
            {
                pizza.AfficherPizza();

            }
        }
    }
}
