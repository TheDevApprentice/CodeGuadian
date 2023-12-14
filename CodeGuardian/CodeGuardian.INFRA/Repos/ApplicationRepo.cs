using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.INFRA.Repos;

public class ApplicationRepo : IApplicationRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public ApplicationRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    List<Application> IApplicationRepo.GetAllApplication()
    {
        return _dbCodeGuardian.Applications.ToList();
    }

    Application IApplicationRepo.GetApplicationById(int id)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Applications.FirstOrDefault(licence => licence.Id == id);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.

    }
}