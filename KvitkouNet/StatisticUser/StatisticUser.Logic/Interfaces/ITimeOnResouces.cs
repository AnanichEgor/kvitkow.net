using System;
using System.Collections.Generic;
using System.Text;

namespace StatisticUser.Logic.Interfaces
{
    public interface ITimeOnResouces
    {
        string Resource { get; set; }
        DateTime DateTime { get; set; }
        TimeSpan TimeOnResource { get; set; }
    }
}
