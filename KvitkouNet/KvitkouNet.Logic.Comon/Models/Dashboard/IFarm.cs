using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Models.Dashboard
{
    public interface IFarm
    {
        void Add(string name, Func<object> factory);
        void Remove(string name);
        void GetUp(string name);
    }
}
