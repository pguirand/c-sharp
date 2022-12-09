//using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace pizza_mama.Models
{
    public class Pizza
    {
        [JsonIgnore]
        public int PizzaID { get; set; }
        [Display(Name ="Name")]
        public string nom { get; set; }
        [Display(Name ="Price")]
        public float prix { get; set; }
        [Display(Name ="Vegie")]
        public bool vegetarienne { get; set; }
        [Display(Name ="Ingredients")]
        [JsonIgnore]
        public string ingredients { get; set; }
        [NotMapped]
        [JsonPropertyName("ingredients")]
        public string[] listeIngredients
        {
            get
            {
                if ((ingredients == null) || (ingredients.Count() == 0))
                {
                    return null;
                }

                return ingredients.Split(", ");
            }
        }
    }
}
