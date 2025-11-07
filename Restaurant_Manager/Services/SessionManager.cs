using Restaurant_Manager.Entity;

namespace Restaurant_Manager.Services
{
    public static class SessionManager
    {
        public static User? CurrentUser { get; set; }

        public static bool HasRole(string roleName)
        {
            return CurrentUser?.Role?.Name == roleName;
        }
    }
}
