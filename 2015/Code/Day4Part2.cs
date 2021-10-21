using System;
using System.Text;

namespace adventCoins
{
    class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;
            int secretNumber = 0;
            string secretKey = "iwrupvqb";
            while (cont)
            {
                string combined = secretKey + secretNumber.ToString();
                string MD5hash = getMD5(combined);
                if (MD5hash.Substring(0, 6) == "000000")
                {
                    Console.WriteLine($"The lowest positive number that producesa 00000 starting has is {secretNumber}");
                    Console.ReadKey();
                    cont = false;
                }
                secretNumber++;
            }
        }

        public static string getMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                //Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}