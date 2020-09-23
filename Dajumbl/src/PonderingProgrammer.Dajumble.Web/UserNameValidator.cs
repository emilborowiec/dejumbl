using System.Collections.Generic;
using System.Linq;

namespace PonderingProgrammer.Dajumble.Web
{
    public static class UserNameValidator
    {
        public static IEnumerable<string> ValidateUserName(string userName)
        {
            if (userName == null)
            {
                yield return "Username is null";
                yield break;
            }
            if (userName.Length == 0) yield return "Username is empty";
            if (userName.Length > 39) yield return "Username cannot be longer than 39 characters";
            var allowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            if (userName.Any(c => !allowedCharacters.Contains(c))) yield return "Username contains invalid characters - only English letters and digits allowed";
        }
    }
}