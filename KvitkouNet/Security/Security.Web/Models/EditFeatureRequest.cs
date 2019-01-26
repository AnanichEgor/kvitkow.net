using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class EditFeatureRequest
    {
        public int FeatureId { get; set; }
        public int[] RightsIds { get; set; }
    }
}
