const fs = require('fs');

// Write user data to the temporary file
fs.writeFile('/tmp/sensitive_data.csv, user_data, (err) => {
  if (err) throw err;
  console.log('Sensitive data written to temporary file');
});

// Encrypt the file contents and save the result in a variable
encrypted = encryptFile('/tmp/sensitive_data.csv');

// Send the encrypted contents to S3
backupToS3Bucket(encrypted);

// Delete the temporary file
fs.unlink('/tmp/sensitive_data.csv', (err) => {
  if (err) throw err;
  console.log('File deleted successfully');
});