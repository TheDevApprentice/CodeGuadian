using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAINE.Interfaces;

public interface IPermissionService
{
    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);
}