﻿namespace Security.Data.Models
{
    /// <summary>
    /// Многие ко многим AccessFunction и AccessRight
    /// </summary>
    internal class AccessFunctionAccessRight
    {
        public int AccessFunctionId { get; set; }

        public AccessFunction AccessFunction { get; set; }

        public int AccessRightId { get; set; }

        public AccessRight AccessRight { get; set; }
    }
}
