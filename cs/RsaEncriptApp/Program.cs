using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string privateKeyPath = "private_key.xml";
        string publicKeyPath = "public_key.xml";
        string messagePath = "message.txt";
        string encryptedMessagePath = "encrypted_message.bin";

        // Generate RSA keys
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(2048))
        {
            // Save private key
            File.WriteAllText(privateKeyPath, rsa.ToXmlString(true));

            // Save public key
            File.WriteAllText(publicKeyPath, rsa.ToXmlString(false));

            Console.WriteLine("Keys generated and saved.");
        }

        // Encrypt a message
        string message = File.ReadAllText(messagePath);
        byte[] messageBytes = Encoding.UTF8.GetBytes(message);

        byte[] encryptedMessage;
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(File.ReadAllText(publicKeyPath));
            encryptedMessage = rsa.Encrypt(messageBytes, false);
        }

        // Save the encrypted message
        File.WriteAllBytes(encryptedMessagePath, encryptedMessage);
        Console.WriteLine("Message encrypted and saved.");

        // Decrypt the message
        byte[] encryptedMessageFromFile = File.ReadAllBytes(encryptedMessagePath);

        byte[] decryptedMessageBytes;
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(File.ReadAllText(privateKeyPath));
            decryptedMessageBytes = rsa.Decrypt(encryptedMessageFromFile, false);
        }

        string decryptedMessage = Encoding.UTF8.GetString(decryptedMessageBytes);
        Console.WriteLine("Decrypted Message:");
        Console.WriteLine(decryptedMessage);
    }
}
