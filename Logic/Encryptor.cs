using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;
using System.IO;

namespace PasswordManager.Logic
{
    internal class EncryptorAndDecryptor
    {
        private byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            var fileInfo = new FileInfo("salt.txt");

            if (File.Exists("salt.txt")  && fileInfo.Length > 5)
            {
                rng.GetBytes(buffer);
                File.ReadAllBytes("salt.txt");
                return buffer;
            }
            else
            {
                rng.GetBytes(buffer);
                File.WriteAllBytes("salt.txt", buffer);
                return buffer;
            }
        }

        // implementacja metody kasującej stary plik z solą

        private byte[] HashPassword(string password, byte[] salt)
        {            
            var argon2id = new Argon2id(Encoding.UTF8.GetBytes(password));

            argon2id.Salt = salt;            
            argon2id.DegreeOfParallelism = 4;
            argon2id.Iterations = 4;
            argon2id.MemorySize = 1024 * 1024; //1GB

            return argon2id.GetBytes(16);
        }
    private bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }
    public byte[] Enrypt(string password)
        {
            var salt = CreateSalt();
            var hash = HashPassword(password, salt);
           
            var success = VerifyHash(password, salt, hash);
            File.WriteAllBytes("hash.txt", hash);
            
            return hash;
            
        }

    public void checkLoginAndPassword (string login, string password)
        {
            bool loginExists;
            bool passwordIsMatch;
            byte[] hashedPassoword;

            

            int counter = 0;
            string line;
            var text = Console.ReadLine();

            System.IO.StreamReader file =
                new System.IO.StreamReader("database.txt");

            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(login))
                {
                    break;
                }
                counter++;
            }

            

            file.Close();



            var salt = CreateSalt();


            //VerifyHash(password, salt, hashedPassoword);


        }



    }
}