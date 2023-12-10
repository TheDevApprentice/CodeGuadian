using CodeGuardian.DOMAINE.Entity;
using CodeGuardian.DOMAINE.Interfaces;

namespace CodeGuardian.DOMAINE.Services;

public class PermissionService : IPermissionService
{
    private IPermissionRepo _permissionRepo;

    // Initialize the user repository to access the methods
    public PermissionService(IPermissionRepo permissionRepo)
    {
        this._permissionRepo = permissionRepo;
    }

    List<Permission> IPermissionService.GetAlPermissions()
    {
       return _permissionRepo.GetAlPermissions();
    }

    Permission IPermissionService.GetPermissionById(int permissionId)
    {
       return  _permissionRepo.GetPermissionById(permissionId);
    }
}