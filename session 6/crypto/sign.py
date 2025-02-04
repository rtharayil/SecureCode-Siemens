import rsa


(pubkey, privkey) = rsa.newkeys(512)
message = 'some message'.encode()
signature = rsa.sign(message, privkey, 'SHA-1')

message2 = 'some message'.encode()

print(signature.hex())

print(rsa.verify(bytes.fromhex(message2.hex()), signature, pubkey))