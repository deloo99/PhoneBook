using System;
using System.Security.Cryptography;
using System.Text;

namespace PhoneBook.Classes
{
    public static class Cryptography
    {
        public static byte[] GetEntropy(string EntropyString)
            => MD5.Create().ComputeHash(Encoding.UTF8.GetBytes(EntropyString));

        public static string EncryptPassword(string login, string password)
            => (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                ? string.Empty
                : Convert.ToBase64String(
                    ProtectedData.Protect(
                        Encoding.UTF8.GetBytes(password),
                        GetEntropy(login),
                        DataProtectionScope.CurrentUser
                    ));

        public static string DecryptPassword(string login, string password)
            => string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)
                ? string.Empty
                : Encoding.UTF8.GetString(
                    ProtectedData.Unprotect(
                        Convert.FromBase64String(password),
                        GetEntropy(login),
                        DataProtectionScope.CurrentUser
                    ));
    }
}
