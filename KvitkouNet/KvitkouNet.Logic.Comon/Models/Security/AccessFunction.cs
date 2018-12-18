using System;
using System.Collections.Generic;

namespace KvitkouNet.Logic.Common.Models.Security
{
    public class AccessFunction
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string FeatureName { get; set; }

        public List<AccessRight> AccessRights { get; set; }
    }
}
