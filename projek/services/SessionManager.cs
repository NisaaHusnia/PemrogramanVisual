public static class SessionManager
{
    public static bool IsLoggedIn { get; private set; } = false;
    public static string Username { get; private set; } = "";

    public static void Login(string username)
    {
        IsLoggedIn = true;
        Username = username;
    }

    public static void Logout()
    {
        IsLoggedIn = false;
        Username = "";
    }
}