using System;
using BCrypt.Net;

class Program
{
    static void Main(string[] args)
    {
        string password = "password123";

        // Generate salt and hash the password with a work factor of 15
        string salt = BCrypt.Net.BCrypt.GenerateSalt(15);
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

        // Check if the password matches the hash
        if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
        {
            Console.WriteLine("Password is correct");
        }
        else
        {
            Console.WriteLine("Password is incorrect");
        }
    }
}
