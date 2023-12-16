using CodeGuardian.DOMAIN.Entity.Application;
using CodeGuardian.DOMAINE.Interfaces;
using License = CodeGuardian.DOMAINE.Entity.License;

namespace CodeGuardian.INFRA.Repos;

public class ApplicationRepo : IApplicationRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public ApplicationRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    License IApplicationRepo.CheckApplicationLicenceKey(string licenseKeyEncryptedHash)
    {
        var list = _dbCodeGuardian.Licenses.ToList();
        License licence = (License)list.Where(x => x.KeyHash == licenseKeyEncryptedHash);
        if (licence != null)
        {
            // decryption de la 
        }
        return licence;
    }

    List<Application> IApplicationRepo.GetAllApplication()
    {
        return _dbCodeGuardian.Applications.ToList();
    }

    Application IApplicationRepo.GetApplicationById(Guid id)
    {
        return _dbCodeGuardian.Applications.FirstOrDefault(licence => licence.Uuid == id);
    }
}