using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Beginner.Models
{
    public class PokemonInfo
    {
        public string name { get; set; }
        public int height { get; set; }
        public int weight { get; set; }
        public Sprite sprite { get; set; }


        //public class URL
        //{
        //    public string name { get; set; }
        //    public string height { get; set; }
        //    public string weight { get; set; }
        //    public Sprite sprites { get; set; }
        //}

        public class Sprite
        {
            public string front_default { get; set; }
            public string back_default { get; set; }
        }

        public class AllPokemonAPI
        {
            public List<ResultObject> results { get; set; }
        }

        public class ResultObject
        {
            public string name { get; set; }
            public string url { get; set; }

            public override string ToString()
            {
                return name;
            }
        }
    }
}
    //    public List<Ability> abilities { get; set; }
    //    public int base_experience { get; set; }
    //    public List<Form> forms { get; set; }
    //    public List<GameIndice> game_indices { get; set; }
    //    public int height { get; set; }
    //    public List<HeldItem> held_items { get; set; }
    //    public int id { get; set; }
    //    public bool is_default { get; set; }
    //    public string location_area_encounters { get; set; }
    //    public List<Move> moves { get; set; }
    //    public string name { get; set; }
    //    public int order { get; set; }
    //    public Species species { get; set; }
    //    public Sprite sprites { get; set; }
    //    public List<Stat> stats { get; set; }
    //    public List<Type> types { get; set; }
    //    public int weight { get; set; }
    //}

    //public class Ability2
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class Ability
    //{
    //    public Ability2 ability { get; set; }
    //    public bool is_hidden { get; set; }
    //    public int slot { get; set; }
    //}

    //public class Form
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class Version
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class GameIndice
    //{
    //    public int game_index { get; set; }
    //    public Version version { get; set; }
    //}

    //public class Item
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class Version2
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class VersionDetail
    //{
    //    public int rarity { get; set; }
    //    public Version2 version { get; set; }
    //}

    //public class HeldItem
    //{
    //    public Item item { get; set;}
    //    public List<VersionDetail> version_details { get; set; }
    //}

    //public class Move2
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class MoveLearnMethod
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class VersionGroup
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class VersionGroupDetail
    //{
    //    public int level_learned_at { get; set; }
    //    public MoveLearnMethod move_learn_method { get; set; }
    //    public VersionGroup version_group { get; set; }
    //}

    //public class Move
    //{
    //    public Move2 move { get; set; }
    //    public List<VersionGroupDetail> version_group_details { get; set; }
    //}

    //public class Species
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}

    //public class DreamWorld
    //{
    //    public string front_default { get; set; }
    //    public object front_female { get; set; }
    //}

    //public class OfficialArtwork
    //{
    //    public string front_default { get; set; }
    //}

    //public class Other
    //{
    //    public DreamWorld dream_world { get; set; }
    //    [JsonProperty("official-artwork")]

    //    public OfficialArtwork OfficialArtwork { get; set; }
    //}

    //public class RedBlue
    //{
    //    public string back_default { get; set; }
    //    public string back_gray { get; set; }
    //    public string front_default { get; set; }
    //    public string front_gray { get; set; }
    //}

    //public class Yellow
    //{
    //    public string back_default { get; set; }
    //    public string back_gray { get; set; }
    //    public string front_default { get; set; }
    //    public string front_gray { get; set; }
    //}

    //public class Generation1
    //{
    //    [JsonProperty("red-blue")]

    //    public RedBlue RedBlue { get; set; }
    //    public Yellow yellow { get; set; }
    //}

    //public class Crystal
    //{
    //    public string back_default { get; set; }
    //    public string back_shiny { get; set; }
    //    public string front_default { get; set; }
    //    public string front_shiny { get; set; }
    //}

    //public class Gold
    //{

    //}

    //public class Sprites
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //    public string back_default { get; set; }
    //    public string back_gray { get; set; }
    //    public string front_default { get; set; }
    //    public string front_gray { get; set; }
    //}

    //public class Stat
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //}
//}