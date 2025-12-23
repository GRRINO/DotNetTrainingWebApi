using Effortless.Net.Encryption;
using System.Text;

namespace EncDecExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // a thay key
            byte[] key = Encoding.ASCII.GetBytes("b14ca5898a4e4133bbce2ea2315a1916");
            byte[] iv = Encoding.ASCII.GetBytes("b14ca5898a4e4133");


            // a shin kkey
            //byte[] key = Bytes.GenerateKey();
            //byte[] iv = Bytes.GenerateIV();

            string encrypted = Strings.Encrypt("Secret Message", key, iv);
            Console.WriteLine(encrypted);
            string decrypted = Strings.Decrypt(encrypted, key, iv);
            Console.WriteLine(decrypted);

            Console.ReadLine();
        }
    }
}
