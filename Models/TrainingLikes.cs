using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class TrainingLikes
    {
        public int TrainingLikesId { get; set; }
        public bool Action { get; set; }
        public int TrainingId { get; set; }
        public int UserId { get; set; }

        public Training Training { get; set; }
        public User User { get; set; }
    }
}
