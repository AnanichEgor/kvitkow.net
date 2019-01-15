using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Data.DbModels
{
    public class UserGroupDB
    {
        public string UserId { get; set; }
        public UserDB User { get; set; }
        public int GroupId { get; set; }
        public GroupDB Group { get; set; }
    }
}
