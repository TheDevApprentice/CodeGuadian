using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Users.Dev;

public class Dev : Person
{
    public Dev()
    {
        Permissions = new List<DevPermission>();
    }

    public Guid Uuid { get; set; } = Guid.NewGuid();
    public ICollection<DevPermission> Permissions { get; set; }
}