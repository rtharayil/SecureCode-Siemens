using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        // Generate a random key (32 bytes for AES-256)
        byte[] key = GenerateKey();
        Console.WriteLine("Generated Key: " + Convert.ToBase64String(key));

        // Original plaintext message
        string plaintext = "welcome to geeksforgeeks";
        Console.WriteLine("Original Plaintext: " + plaintext);

        // Encrypt the plaintext
        byte[] encrypted = Encrypt(plaintext, key);
        Console.WriteLine("Encrypted Ciphertext (Base64): " + Convert.ToBase64String(encrypted));

        // Decrypt the ciphertext
        string decrypted = Decrypt(encrypted, key);
        Console.WriteLine("Decrypted Plaintext: " + decrypted);
    }

    // Generate a 256-bit random key
    static byte[] GenerateKey()
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] key = new byte[32]; // 32 bytes = 256 bits for AES-256
            rng.GetBytes(key);
            return key;
        }
    }

    static byte[] Encrypt(string plaintext, byte[] key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.GenerateIV(); // Generate a random IV

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

                // Prepend the IV to the encrypted data
                byte[] result = new byte[aes.IV.Length + encryptedBytes.Length];
                Buffer.BlockCopy(aes.IV, 0, result, 0, aes.IV.Length);
                Buffer.BlockCopy(encryptedBytes, 0, result, aes.IV.Length, encryptedBytes.Length);

                return result;
            }
        }
    }

    static string Decrypt(byte[] encryptedData, byte[] key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = key;

            // Extract the IV from the beginning of the encrypted data
            byte[] iv = new byte[16]; // AES block size is 16 bytes
            byte[] ciphertext = new byte[encryptedData.Length - iv.Length];
            Buffer.BlockCopy(encryptedData, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(encryptedData, iv.Length, ciphertext, 0, ciphertext.Length);

            aes.IV = iv;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            {
                byte[] decryptedBytes = decryptor.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}
