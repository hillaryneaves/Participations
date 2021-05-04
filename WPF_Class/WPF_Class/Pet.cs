using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Class
{
    public class Pet
    {
        public string Name { get; set; }

        public string Breed { get; set; }

        public string PictureURL { get; set;  }

        public Pet()
        {
            Name = string.Empty;
            Breed = string.Empty;
            PictureURL = string.Empty;
        }

        public override string ToString()
        {
            return $"{Name} ({Breed})";
        }
    }
}
