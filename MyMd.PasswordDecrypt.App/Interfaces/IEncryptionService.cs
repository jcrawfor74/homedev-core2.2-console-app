namespace MyMd.PasswordDecrypt.App.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText);

        string Decrypt(string cipherText);

        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string password);
    }
}