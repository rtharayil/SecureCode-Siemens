import rsa

# Generate an RSA key pair with a specified key size (e.g., 2048 bits)
(public_key, private_key) = rsa.newkeys(2048)

# Save the private key to a file
with open('private_key.pem', 'wb') as private_key_file:
    private_key_bytes = private_key.save_pkcs1(format='PEM')
    private_key_file.write(private_key_bytes)

# Save the public key to a file
with open('public_key.pem', 'wb') as public_key_file:
    public_key_bytes = public_key.save_pkcs1(format='PEM')
    public_key_file.write(public_key_bytes)



with open('private_key.pem', 'rb') as private_key_file:
    private_key_data = private_key_file.read()
    private_key = rsa.PrivateKey.load_pkcs1(private_key_data)

# Load the public key from a file
with open('public_key.pem', 'rb') as public_key_file:
    public_key_data = public_key_file.read()
    public_key = rsa.PublicKey.load_pkcs1(public_key_data)


print("public_key string: ", public_key.save_pkcs1(format = 'PEM') )
print("private_key string: ", private_key.save_pkcs1(format = 'PEM') )



# Read the message from a file
with open('message.txt', 'rb') as message_file:
    message = message_file.read()


# Encrypt the message
encrypted_message = rsa.encrypt(message, public_key)

# Save the encrypted message to a file
with open('encrypted_message.bin', 'wb') as encrypted_message_file:
    encrypted_message_file.write(encrypted_message)


# Read the encrypted message from a file
with open('encrypted_message.bin', 'rb') as encrypted_message_file:
    encrypted_message = encrypted_message_file.read()

# Decrypt the message
decrypted_message = rsa.decrypt(encrypted_message, private_key)

print("Decrypted Message:")
print(decrypted_message.decode('utf-8'))