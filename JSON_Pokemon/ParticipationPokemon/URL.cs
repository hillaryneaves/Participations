using System;
using System.Collections.Generic;
using System.Text;

namespace ParticipationPokemon
{
    public class URL
    {
        public string height { get; set; }
        public string weight { get; set; }
        public Sprite sprites { get; set; }
    }

    public class Sprite
    {
        public string front_default { get; set; }
        public string back_default { get; set; }
    }
}