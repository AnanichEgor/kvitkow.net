using System;
using KvitkouNet.Logic.Common.Enums;
using KvitkouNet.Logic.Common.Models;

namespace KvitkouNet.Logic.Common.Models.PaymentManagement
{
    /// <summary>
    /// Provides transaction`s data
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Transaction unique number
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Currency type
        /// </summary>
        public CurrencyType Currency { get; set; }

        ///<summary>
        ///Ammount 
        ///</summary>
        public double Ammount { get; set; }

        ///<summary>
        ///Description
        /// </summary>
        public string Description { get; set; }
    }
}
