using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Client.PowerUser;

public class PowerUser : ClientObject
{
    public PowerUser()
    {
        PowerUserAdmins = new List<PowerUserAdmins>();
        PowerUserApplications = new List<PowerUserApplication>();
        PowerUserDevs = new List<PowerUserDevs>();
    }
    public Guid Uuid { get; set; } = Guid.NewGuid();
    public ICollection<PowerUserAdmins> PowerUserAdmins { get; set; }

    public ICollection<PowerUserApplication> PowerUserApplications { get; set; }
    public ICollection<PowerUserDevs> PowerUserDevs { get; set; }
}
