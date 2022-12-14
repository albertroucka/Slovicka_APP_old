using System;
using System.Collections.Generic;
using System.Text;

namespace Slovicka_APP.Models
{
    class MainClass
    {

        public string GetUserName()
        {
            return "Albert R.";
        }

        public string GetUserTrophiesCount()
        {
            return "123";
        }

        public List<string> GetAllExerciseTypes()
        {
            List<string> allExercises = new List<string>() { "Překlad slov", "Výběr z možností", "Kartičky" };
            return allExercises;
        }

        public List<string> GetAllLanguages()
        {
            List<string> Lang = new List<string>() { "Anglicky", "Česky", "Německy" };
            return Lang;
        }

    }
}
