using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class SportТype
    {
        public SportТype()
        {
            Training = new HashSet<Training>();
            User = new HashSet<User>();
        }

        public int SportTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Training> Training { get; set; }
        public ICollection<User> User { get; set; }
    }
}
