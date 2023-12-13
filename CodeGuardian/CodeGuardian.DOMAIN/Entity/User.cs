namespace CodeGuardian.DOMAINE.Entity;

public class User : Person
{
    public User()
    {
        IsAdmin = false;
        Permissions = new List<UserPermission>();
        Applications = new List<UserApplications>();
    }

    public Guid Uuid { get; set; }

    public ICollection<UserApplications> Applications { get; set; }

    public ICollection<UserPermission> Permissions { get; set; }
}