using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class TrainingType
    {
        public TrainingType()
        {
            Training = new HashSet<Training>();
        }

        public int TrainingTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<Training> Training { get; set; }
    }
}
