using System;
public static class InputValidator
{
    public static bool ValidateTaskInputs(string title, string description, DateTime deadline, out string errorMessage)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            errorMessage = "Judul tidak boleh kosong.";
            return false;
        }

        if (deadline < DateTime.Today)
        {
            errorMessage = "Deadline tidak boleh kurang dari hari ini.";
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}