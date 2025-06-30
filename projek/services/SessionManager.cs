public static class SessionManager
{
    public static bool IsLoggedIn { get; private set; } = false;
    public static int CurrentUserId { get; private set; }
    public static string CurrentUsername { get; private set; } = "";

    public static void Login(int userId, string username)
    {
        CurrentUserId = userId;
        CurrentUsername = username;
        IsLoggedIn = true;
    }

    public static void Logout()
    {
        CurrentUserId = 0;
        CurrentUsername = "";
        IsLoggedIn = false;
    }
}
