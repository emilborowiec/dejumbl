using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Dejumble.Web
{
    public static class Validators
    {
        const string UrlFriendlyCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-";
        
        public static IEnumerable<string> ValidateForUrlFriendliness(string value)
        {
            if (value == null)
            {
                yield return "Value is null";
                yield break;
            }
            if (value.Length == 0) yield return "Value is empty";
            if (value.Length > 39) yield return "Value cannot be longer than 39 characters";
            if (value.Any(c => !UrlFriendlyCharacters.Contains(c))) yield return "Value contains invalid characters - only English letters, digits and hyphens are allowed";
            if (value.StartsWith("-") || value.EndsWith("-")) yield return "Value cannot start or end with -";
            if (value.Contains("--")) yield return "Value cannot contain consecutive - signs";
        }
    }
}