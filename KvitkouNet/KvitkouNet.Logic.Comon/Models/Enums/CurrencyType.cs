using System;
using System.Collections.Generic;
using System.Text;

namespace KvitkouNet.Logic.Common.Enums
{
    /// <summary>
    /// Provides currency type
    /// </summary>
    public enum CurrencyType
    {
        BYN = 0,
        RUB = 1 << 0,
        USD = 1 << 1,
        EUR = 1 << 2
    }
}
