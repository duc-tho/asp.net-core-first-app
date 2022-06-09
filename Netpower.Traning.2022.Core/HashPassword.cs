using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Netpower.Traning._2022.Core
{
     public static class HashPassword
     {
          public static string Hash(string password)
          {
               byte[] salt = new byte[128 / 8];

               string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2
               (
                    password: password,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8)
               );

               return hashed;
          }
     }
}
