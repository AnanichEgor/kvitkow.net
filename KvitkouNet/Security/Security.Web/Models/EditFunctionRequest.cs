using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Web.Models
{
    public class EditFunctionRequest
    {
        public int FunctionId { get; set; }
        public int[] RightIds { get; set; }
    }
}
