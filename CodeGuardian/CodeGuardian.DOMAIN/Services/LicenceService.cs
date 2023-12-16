using CodeGuardian.API.Controllers;
using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace CodeGuardian.DOMAINE.Services;

public class LicenceService : ILicenceService
{
    private ILicenceRepo _licenceRepo;
    public LicenceService(ILicenceRepo licenceRepo)
    {
        this._licenceRepo = licenceRepo;
    }

    License ILicenceService.CreateLicenceKey(License licence)
    {
        licence.Uuid = GenerateUUID();
        licence.KeyHash = SignLicenseKey(licence, null);
        licence.Status = "Active";
        return _licenceRepo.AddCreatedLicenceKey(licence);
    }

    List<License> ILicenceService.GetAllLicenses()
    {
        return _licenceRepo.GetAllLicenses();
    }

    License ILicenceService.GetLicenseById(Guid licenceId)
    {
        return _licenceRepo.GetLicenseById(licenceId);
    }

    private Guid GenerateUUID()
    {
        return Guid.NewGuid();
    }

    private string SignLicenseKey(License license, RSACryptoServiceProvider privateKey)
    {
        byte[] data = Encoding.UTF8.GetBytes(license.Application.Uuid.ToString() + license.Uuid.ToString());
        byte[] signature = privateKey.SignData(data, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        return Convert.ToBase64String(signature);
    }

    private bool ValidateLicenseKey(string licenseKey, string storedSignature, RSACryptoServiceProvider publicKey)
    {
        byte[] data = Encoding.UTF8.GetBytes(licenseKey);
        byte[] signature = Convert.FromBase64String(storedSignature);
        return publicKey.VerifyData(data, signature, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
    }

    private string EncryptUuid(Guid uuid)
    {
        using (Aes aesAlg = Aes.Create())
        {
            Auth _auth = new Auth();
            string configuration = _auth.ExtractConfiguration("");

            aesAlg.Key = Encoding.UTF8.GetBytes(configuration);
            aesAlg.IV = new byte[16]; // Initialization Vector (IV)

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(uuid.ToString());
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    private Guid DecryptUuid(string encryptedUuid)
    {
        using (Aes aesAlg = Aes.Create())
        {
            Auth _auth = new Auth();
            string configuration = _auth.ExtractConfiguration("");

            aesAlg.Key = Encoding.UTF8.GetBytes(configuration);
            aesAlg.IV = new byte[16]; // Initialization Vector (IV)

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedUuid)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        string decryptedUuid = srDecrypt.ReadToEnd();
                        return Guid.Parse(decryptedUuid);
                    }
                }
            }
        }
    }
}