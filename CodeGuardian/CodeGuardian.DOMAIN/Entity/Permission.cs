namespace CodeGuardian.DOMAINE.Entity;

public class Permission
{
    public int Id { get; set; }
    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string Name { get; set; }
}