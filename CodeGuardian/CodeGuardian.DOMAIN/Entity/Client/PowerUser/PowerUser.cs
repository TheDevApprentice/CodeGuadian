using CodeGuardian.DOMAINE.Entity;

namespace CodeGuardian.DOMAIN.Entity.Client.PowerUser;

public class PowerUser : ClientObject
{
    public PowerUser()
    {
        PowerUserAdmins = new List<PowerUserAdmins>();
        PowerUserApplications = new List<PowerUserApplication>();
    }

    public ICollection<PowerUserAdmins> PowerUserAdmins { get; set; }

    public ICollection<PowerUserApplication> PowerUserApplications { get; set; }
}
