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

    public List<License> GetAllLicenses()
    {
        return _dbCodeGuardian.Licenses.ToList();
    }

    License ILicenceRepo.GetLicenseById(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Licenses.FirstOrDefault(licence => licence.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}