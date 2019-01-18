using System;
using System.Collections.Generic;
using Security.Logic.Models;

namespace Security.Logic.Tests.Comparers
{
    public class AccessRightComparer : Comparer<AccessRight>
    {
        public override int Compare(AccessRight x, AccessRight y)
        {
            if (object.ReferenceEquals(x, y)) return 0;

            if (object.ReferenceEquals(x, null))
                return -1;
            if (object.ReferenceEquals(y, null))
                return 1;

            if (x.Id == y.Id && x.Name == y.Name)
            {
                return 0;
            }

            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
