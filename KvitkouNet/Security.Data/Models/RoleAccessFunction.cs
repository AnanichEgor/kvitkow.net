﻿namespace Security.Data.Models
{
    /// <summary>
    /// Многие ко многим Role и AccessFunction
    /// </summary>
    internal class RoleAccessFunction
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int AccessFunctionId { get; set; }

        public AccessFunction AccessFunction { get; set; }
    }
}
