using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Beginner.Models
{
    public class PokemonInfo
    {
        public string name { get; set; }
        public string height { get; set; }
        public string weight { get; set; }
        public Sprite sprite { get; set; }
    }
    public class Sprite
    {
         public string front_default { get; set; }
         public string back_default { get; set; }
    }
}