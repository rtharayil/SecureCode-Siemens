using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Create a new RSA key pair
        using (RSA rsa = RSA.Create())
        {
            rsa.KeySize = 512;

            // Generate public and private keys
            RSAParameters publicKey = rsa.ExportParameters(false);
            RSAParameters privateKey = rsa.ExportParameters(true);

            // Message to sign
            string message = "some message";
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);

            // Sign the message using SHA1
            byte[] signature = rsa.SignData(messageBytes, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

            // Print signature in hex format
            Console.WriteLine("Signature (Hex): " + BitConverter.ToString(signature).Replace("-", "").ToLower());

            // Verify the message
            bool isVerified = rsa.VerifyData(messageBytes, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);

            Console.WriteLine("Signature Verified: " + isVerified);
        }
    }
}
