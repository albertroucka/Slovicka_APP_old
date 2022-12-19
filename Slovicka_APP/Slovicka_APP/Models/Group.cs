using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slovicka_APP.Models
{
    public class Group
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }

        public string UserId { get; set; }
        public string GroupName { get; set; }
        public string FirstLang { get; set; }
        public string SecondLang { get; set; }
        public int NumberOfExercises { get; set; }
        public double SuccessRate { get; set; }
    }
}
