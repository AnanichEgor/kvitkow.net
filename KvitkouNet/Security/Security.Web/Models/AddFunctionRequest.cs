using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class AddFunctionRequest
    {
        public string FunctionName { get; set; }
        public int FeatureId { get; set; }
    }
}
