using Security.Data.Exceptions;

namespace Security.Logic.Helpers
{
    static class PrettyExceptionHelper
    {
        public static string GetMessage(SecurityDbException e)
        {
            var entityName = string.Empty;

            switch (e.EntityType)
            {
                case EntityType.Right:
                    entityName = "Access Right";
                    break;
                case EntityType.Function:
                    entityName = "Access Function";
                    break;
                case EntityType.Feature:
                    entityName = "Feature";
                    break;
                case EntityType.Role:
                    entityName = "Role";
                    break;
                case EntityType.UserRights:
                    entityName = "User Rights";
                    break;
            }
            switch (e.Code)
            {
                case ExceptionType.NameExists:
                    return $"Names: {string.Join(",", e.Items)} of {entityName} already exist";
                case ExceptionType.NotFound:
                    return $"{entityName} with id = {string.Join(",", e.Items)} was not found";
            }

            return "Unknown code of error";
        }
    }
}
