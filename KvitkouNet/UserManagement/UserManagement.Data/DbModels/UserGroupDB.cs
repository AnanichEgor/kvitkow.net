using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement.Data.DbModels
{
    public class UserGroupDB
    {
        public string UserId { get; set; }
        public UserDB User { get; set; }
        public string GroupId { get; set; }
        public GroupDB Group { get; set; }
    }
}
