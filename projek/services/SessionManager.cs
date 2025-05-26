namespace MyFirstApp.projek.services
{
    public static class SessionManager
    {
        public static bool IsLoggedIn { get; set; } = false;
        public static string Username { get; set; } = "";
    }
}
