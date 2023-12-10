using CodeGuardian.DOMAINE.Entity;
namespace CodeGuardian.DOMAINE.Interfaces;

public interface IPermissionRepo
{
    List<Permission> GetAlPermissions();

    Permission GetPermissionById(int permissionId);
}