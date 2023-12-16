using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.INFRA.Repos;

public class LicenceRepo : ILicenceRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public LicenceRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    public License AddCreatedLicenceKey(License newlicence)
    {
        _dbCodeGuardian.Licenses.Add(newlicence);
        _dbCodeGuardian.SaveChanges();
        return newlicence;
    }

    List<License> ILicenceRepo.GetAllLicenses()
    {
        return _dbCodeGuardian.Licenses.ToList();
    }

    License ILicenceRepo.GetLicenseById(Guid id)
    {
        return _dbCodeGuardian.Licenses.FirstOrDefault(licence => licence.Uuid == id);
    }
}