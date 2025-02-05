import hashlib

def hash_passcode(passcode):
    # Create a SHA-256 hash object
    sha256 = hashlib.sha256()

    # Update the hash object with the passcode encoded as bytes
    sha256.update(passcode.encode('utf-8'))

    # Get the hexadecimal representation of the hashed passcode
    hashed_passcode = sha256.hexdigest()

    return hashed_passcode

# Example usage
passcode = "mySecurePass123"
hashed_passcode = hash_passcode(passcode)

print("Original Passcode:", passcode)
print("Hashed Passcode:", hashed_passcode)
