using System;
namespace Security.Data.Exceptions
{
    public class SecurityDbException : Exception
    {
        public SecurityDbException(string message, ExceptionType code, EntityType entityType, string[] items) : base(message)
        {
            Code = code;
            EntityType = entityType;
            Items = items;
        }

        public ExceptionType Code { get; set; }

        public EntityType EntityType { get; set; }

        public string[] Items { get; set; }
    }
}
