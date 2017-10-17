using System;
using System.Collections.Generic;

namespace TrainingBookApp.Models
{
    public partial class GroupМember
    {
        public int GroupMemberId { get; set; }
        public int UserId { get; set; }
        public int UserGroupId { get; set; }

        public User User { get; set; }
        public UserGroup UserGroup { get; set; }
    }
}
