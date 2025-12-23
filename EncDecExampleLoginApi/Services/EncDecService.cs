
using Effortless.Net.Encryption;
using System.Security.Cryptography.Xml;
using System.Text;

namespace EncDecExampleLoginApi.Services
{
    public class EncDecService
    {
        private readonly byte[] key;
        private readonly byte[] iv;

        public EncDecService(IConfiguration configuration)
        {
            key = Encoding.ASCII.GetBytes(configuration["Security:KEY"]);
            iv = Encoding.ASCII.GetBytes(configuration["Security:IV"]);
        }

        public string Encrypt(string text) { 
        
            return Strings.Encrypt(text, key, iv);
        }

        public string Decrypt(string encryptText)
        {

            return Strings.Decrypt(encryptText, key, iv);
        }

        // a shin kkey
        //byte[] key = Bytes.GenerateKey();
        //byte[] iv = Bytes.GenerateIV();

       

    }
}
