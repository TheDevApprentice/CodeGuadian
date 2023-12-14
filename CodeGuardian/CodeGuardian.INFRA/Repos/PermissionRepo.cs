using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.INFRA.Repos;

public class PermissionRepo : IPermissionRepo
{
    private CodeGuardianDbContext _dbCodeGuardian;

    public PermissionRepo(CodeGuardianDbContext CodeGuardianDbContext)
    {
        this._dbCodeGuardian = CodeGuardianDbContext;
    }

    List<Permission> IPermissionRepo.GetAlPermissions()
    {
        return _dbCodeGuardian.Permissions.ToList();
    }

    Permission IPermissionRepo.GetPermissionById(int permissionId)
    {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
        return _dbCodeGuardian.Permissions.FirstOrDefault(licence => licence.Id == permissionId);
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
    }
}