using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.API.ApiCalls
{
    public class UserAPICalls
    {
        public static string GetControllerName()
        {
            string controllerName = "api/" + nameof(User);
            return controllerName;
        }

        public const string GetAllUsers = "users";
        public const string AddAnUser = "user";

        public static string GetAllUsersFullPath()
        {
            return GetControllerName();
        }

        public static string AddUserFullPath()
        {
            return GetControllerName();
        }

    }
}