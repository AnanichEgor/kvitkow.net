﻿namespace Security.Data.Models
{
    /// <summary>
    /// Многие ко многим Role и AccessRight
    /// </summary>
    internal class RoleAccessRight
    {
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public int AccessRightId { get; set; }

        public AccessRight AccessRight { get; set; }

        public bool IsDenied { get; set; }
    }
}
