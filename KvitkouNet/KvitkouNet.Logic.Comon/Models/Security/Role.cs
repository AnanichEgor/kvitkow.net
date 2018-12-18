using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Security
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<AccessRight> AccessRights { get; set; }

        public List<AccessRight> DeniedRights { get; set; }

        public List<AccessFunction> AccessFunctions { get; set; }
    }
}
