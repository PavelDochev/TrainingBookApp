using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class Training
    {
        public Training()
        {
            TrainingLikes = new HashSet<TrainingLikes>();
        }

        public int TrainingId { get; set; }
        public int UserId { get; set; }
        public int TrainingTypeId { get; set; }
        public int SportTypeId { get; set; }
        public decimal Distance { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string MapPath { get; set; }
        public sbyte? Public { get; set; }

        public SportТype SportType { get; set; }
        public TrainingType TrainingType { get; set; }
        public User User { get; set; }
        public ICollection<TrainingLikes> TrainingLikes { get; set; }
    }
}
