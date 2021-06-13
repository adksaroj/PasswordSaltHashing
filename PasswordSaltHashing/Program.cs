using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace PasswordSaltHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            var pass = Console.ReadLine();

            var salt = Crypto.GenerateSalt();

            var passSalt = pass + salt;

            var pwdHash = Crypto.HashPassword(passSalt);

            Console.WriteLine($"Password : {pass}");
            Console.WriteLine($"Salt : {salt}");
            Console.WriteLine($"Hashed Password : {pwdHash}");

            Console.WriteLine("Enter assword to verify : ");
            var confirmPassPlain = Console.ReadLine();

            var confirmPassSalted = confirmPassPlain + salt;
            
            var cpsHashed = Crypto.HashPassword(confirmPassSalted);
            bool result = Crypto.VerifyHashedPassword(pwdHash, confirmPassSalted);

            if (pwdHash == cpsHashed)
            {
                Console.WriteLine("Plain Password match..");
            }
            else if(result)
            {
                Console.WriteLine("Password with salt match");
            }
            else
            {
                Console.WriteLine("Password donot match");

            }
            Console.ReadKey();
        }
    }
}
