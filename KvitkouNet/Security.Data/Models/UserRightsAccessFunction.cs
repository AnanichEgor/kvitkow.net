namespace Security.Data.Models
{
    /// <summary>
    /// Многие ко многим UserRights и AccessFunction
    /// </summary>
    internal class UserRightsAccessFunction
    {
        public string UserId { get; set; }

        public UserRights UserRights { get; set; }

        public int AccessFunctionId { get; set; }

        public AccessFunction AccessFunction { get; set; }
    }
}
