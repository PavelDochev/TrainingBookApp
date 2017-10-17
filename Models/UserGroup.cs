using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            GroupMember = new HashSet<GroupМember>();
        }

        public int UserGroupId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
        public ICollection<GroupМember> GroupMember { get; set; }
    }
}
