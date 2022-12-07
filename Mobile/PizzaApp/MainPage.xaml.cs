using PizzaApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Net;

namespace PizzaApp
{
    public partial class MainPage : ContentPage
    {

        enum e_tri
        {
            TRI_AUCUN,
            TRI_NOM,
            TRI_PRIX
        }
        e_tri tri = e_tri.TRI_AUCUN;

        const string KEY_TRI = "tri";



        List<Pizza> pizzas;
        public MainPage()
        {
            InitializeComponent();

            if (Application.Current.Properties.ContainsKey(KEY_TRI))
            {
                tri = (e_tri)Application.Current.Properties[KEY_TRI];
                sortButton.Source = GetImageSourceFromTri(tri);
            }

            //string pizzaJson = "[{\"nom\":\"4 fromages\",\"ingredients\":[\"cantal\",\"mozzarella\",\"fromage de chèvre\",\"gruyère\"],\"prix\":11,\"imageUrl\":\"https://www.galbani.fr/wp-content/uploads/2017/07/pizza_filant_montage_2_3.jpg\"},{\"nom\":\"tartiflette\",\"ingredients\":[\"pomme de terre\",\"oignons\",\"crème fraiche\",\"lardons\",\"mozzarella\"],\"prix\":14,\"imageUrl\":\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOdH8SgZs2A05WyhpK_eGnyyv1NgrYyXarzA&usqp=CAU\r\n\"},{\"nom\":\"margherita\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"basilic\"],\"prix\":7,\"imageUrl\":\"https://www.misteriosocultos.com/wp-content/uploads/2018/12/pizza.jpg\"},{\"nom\":\"indienne\",\"ingredients\":[\"curry\",\"mozzarella\",\"poulet\",\"poivron\",\"oignon\",\"coriandre\"],\"prix\":10,\"imageUrl\":\"https://assets.afcdn.com/recipe/20160519/15342_w1024h768c1cx3504cy2338.jpg\"},{\"nom\":\"mexicaine\",\"ingredients\":[\"boeuf\",\"mozzarella\",\"maïs\",\"tomates\",\"oignon\",\"coriandre\"],\"prix\":13,\"imageUrl\":\"https://fac.img.pmdstatic.net/fit/http.3A.2F.2Fprd2-bone-image.2Es3-website-eu-west-1.2Eamazonaws.2Ecom.2FFAC.2Fvar.2Ffemmeactuelle.2Fstorage.2Fimages.2Fminceur.2Fastuces-minceur.2Fminceur-choix-pizzeria-47943.2F14883894-1-fre-FR.2Fminceur-comment-faire-les-bons-choix-a-la-pizzeria.2Ejpg/750x562/quality/80/crop-from/center/minceur-comment-faire-les-bons-choix-a-la-pizzeria.jpeg\"},{\"nom\":\"chèvre et miel\",\"ingredients\":[\"miel\",\"mozzarella\",\"fromage de chèvre\",\"roquette\"],\"prix\":10,\"imageUrl\":\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVT2IME02lFxO7Tm8NxdDFRvcPc8pw5oNMVw&usqp=CAU\r\n\"},{\"nom\":\"napolitaine\",\"ingredients\":[\"sauce tomate\",\"mozzarella\",\"anchois\",\"câpres\"],\"prix\":9,\"imageUrl\":\"https://www.fourchette-et-bikini.fr/sites/default/files/pizza_tomate_mozzarella.jpg\"},{\"nom\":\"kebab\",\"ingredients\":[\"poulet\",\"oignons\",\"sauce tomate\",\"sauce kebab\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://res.cloudinary.com/serdy-m-dia-inc/image/upload/f_auto/fl_lossy/q_auto:eco/x_0,y_0,w_3839,h_2159,c_crop/w_576,h_324,c_scale/v1525204543/foodlavie/prod/recettes/pizza-au-chorizo-et-fromage-cheddar-en-grains-2421eadb\"},{\"nom\":\"louisiane\",\"ingredients\":[\"poulet\",\"champignons\",\"poivrons\",\"oignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTXJxggtyx_3CFDVx2Vn3Lf-zYZAuMcoI3uag&usqp=CAU\r\n\"},{\"nom\":\"orientale\",\"ingredients\":[\"merguez\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":11,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e30299-pizza-pepperoni-tomate-mozza.jpg\"},{\"nom\":\"hawaïenne\",\"ingredients\":[\"jambon\",\"ananas\",\"sauce tomate\",\"mozzarella\"],\"prix\":12,\"imageUrl\":\"https://www.atelierdeschefs.com/media/recette-e16312-pizza-quatre-saisons.jpg\"},{\"nom\":\"reine\",\"ingredients\":[\"jambon\",\"champignons\",\"sauce tomate\",\"mozzarella\"],\"prix\":8,\"imageUrl\":\"https://static.cuisineaz.com/400x320/i96018-pizza-reine.jpg\"}]";
            //string pizzaJson = "";
            listview.RefreshCommand = new Command((obj) =>
            {
                Console.WriteLine("Refresh Command");

                DownloadData((pizzas) =>
                {
                    listview.ItemsSource = GetPizzasFromTri(tri, pizzas);
                    listview.IsRefreshing = false;
                });

            });

            Console.WriteLine("Phase 1");
            listview.IsVisible = false;
            waitlayout.IsVisible = true;

            // call downloaddata function 
            DownloadData((pizzas) =>
            {
                //listview.ItemsSource = pizzas;
                listview.ItemsSource = GetPizzasFromTri(tri, pizzas);
                listview.IsVisible = true;
                waitlayout.IsVisible = false;
            });
            Console.WriteLine("Phase 4");

            //pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

            //pizzas = new List<Pizza>();
            //pizzas.Add(new Pizza{ nom="vegetarienne", prix=7, ingredients= new string[] {"tomate", "poivrons", "oignons"}, imageurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSOdH8SgZs2A05WyhpK_eGnyyv1NgrYyXarzA&usqp=CAU\r\n" });
            //pizzas.Add(new Pizza{ nom="peperonni", prix=9, ingredients= new string[] {"tomate", "poivrons", "oignons", "peperonni"}, imageurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSVT2IME02lFxO7Tm8NxdDFRvcPc8pw5oNMVw&usqp=CAU\r\n" });
            //pizzas.Add(new Pizza{ nom="hawaii", prix=8, ingredients= new string[] {"tomate", "ananas", "oignons"}, imageurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSkFHVVD2iNIbocUdvwCrFfwie7JZ0eToDxAQ&usqp=CAU\r\n" });
            //pizzas.Add(new Pizza{ nom="griot", prix=12, ingredients= new string[] {"tomate", "pommes de terre","porc", "oignons", "poivrons", "olives", "champignons", "piment", "huile olive","ail","vinaigre", "romarin"}, imageurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSRZIk47n_jEKLbhPSC4kPp9BYNQXSSvrKmyw&usqp=CAU\r\n" });

            //listview.ItemsSource = pizzas;
        }

        public void DownloadData(Action<List<Pizza>> action)
        {
            const string url = "https://drive.google.com/uc?export=download&id=1JOi31kZEZA2FSfdDw8EBO58lFKPxKBct";

            using (var webclient = new WebClient())
            {
              
                    Console.WriteLine("Phase 2");
                    //pizzaJson = webclient.DownloadString(url);
                    webclient.DownloadStringCompleted += (object sender, DownloadStringCompletedEventArgs e) =>
                    {
                        Console.WriteLine("Phase 5");

                        //Console.WriteLine("Data downloaded : " + e.Result);
                        try
                        {
                            string pizzaJson = e.Result;
                            pizzas = JsonConvert.DeserializeObject<List<Pizza>>(pizzaJson);

                            Device.BeginInvokeOnMainThread(() =>
                            {
                                action.Invoke(pizzas);
                            });
                        }
                        catch (Exception ex)
                        {
                            Device.BeginInvokeOnMainThread(() =>
                            {
                                DisplayAlert("ERROR", "Oops, Network Error  : " + ex.Message, "OK");
                                action.Invoke(null);

                            });
                            //return;
                        }

                    };

                    Console.WriteLine("Phase 3");
                    webclient.DownloadStringAsync(new Uri(url));
            
            }

        }

        private void sortButtonClick(object sender, EventArgs e)
        {
            Console.WriteLine("sortButtonClick");
                
            if (tri == e_tri.TRI_AUCUN)
            {
                tri = e_tri.TRI_NOM;
            }
            else if (tri == e_tri.TRI_NOM)
            {
                tri = e_tri.TRI_PRIX;
            }
            else if (tri == e_tri.TRI_PRIX)
            {
                tri = e_tri.TRI_AUCUN;
            }
            sortButton.Source = GetImageSourceFromTri(tri);
            listview.ItemsSource = GetPizzasFromTri(tri, pizzas);

            Application.Current.Properties[KEY_TRI] = (int)tri;
            Application.Current.SavePropertiesAsync();

        }

        private string GetImageSourceFromTri(e_tri t)
        {
            switch(t)
            {
                case e_tri.TRI_NOM:
                    return "sort_nom.png";
                case e_tri.TRI_PRIX:
                    return "sort_prix.png";
            }
            return "sort_none.png";
        }

        private List<Pizza> GetPizzasFromTri(e_tri t, List<Pizza> l)
        {
            if (l == null)
            {
                return null;
            }

            switch (t)
            {
                case e_tri.TRI_NOM:
                    {
                        List<Pizza> ret = new List<Pizza>(l);
                        ret.Sort((p1, p2) => { return p1.Titre.CompareTo(p2.Titre); });
                        return ret;
                    }
                case e_tri.TRI_PRIX:
                    {
                        List<Pizza> ret = new List<Pizza>(l);
                        ret.Sort((p1, p2) => { return p2.prix.CompareTo(p1.prix); });
                        return ret;
                    }
            }
            return l;
        }
    }
}
