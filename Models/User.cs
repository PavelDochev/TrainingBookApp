using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class User
    {
        public User()
        {
            GroupMember = new HashSet<GroupМember>();
            Training = new HashSet<Training>();
            TrainingLikes = new HashSet<TrainingLikes>();
            Usergroup = new HashSet<UserGroup>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int SportTypeId { get; set; }
        public string ClubName { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }

        public SportТype SportType { get; set; }
        public ICollection<GroupМember> GroupMember { get; set; }
        public ICollection<Training> Training { get; set; }
        public ICollection<TrainingLikes> TrainingLikes { get; set; }
        public ICollection<UserGroup> Usergroup { get; set; }
    }
}
