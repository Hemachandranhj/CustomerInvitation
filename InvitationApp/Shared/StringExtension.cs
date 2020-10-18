namespace InvitationApp.Shared
{
    /// <summary>
    /// Extension class to format the json file
    /// </summary>
    public static class StringExtension
    {
        public static string FormatJson(this string value)
        {
            return value.Replace($"}},", "},\n");
        }
    }
}
