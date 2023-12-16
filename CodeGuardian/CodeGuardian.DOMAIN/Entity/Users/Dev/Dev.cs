using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Users.Dev;

public class Dev : Person
{
    public Dev()
    {
        Permissions = new List<DevPermission>();
    }

    public ICollection<DevPermission> Permissions { get; set; }
}