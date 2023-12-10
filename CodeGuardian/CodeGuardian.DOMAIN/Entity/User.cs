namespace CodeGuardian.DOMAINE.Entity;

public class User : Person
{
    public User()
    {
        IsAdmin = false;
        Permissions = new List<UserPermission>();
    }

    public ICollection<UserPermission> Permissions { get; set; }
}