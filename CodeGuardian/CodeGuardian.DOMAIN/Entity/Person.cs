namespace CodeGuardian.DOMAINE.Entity;

public class Person
{
    public int Id { get; set; }

    public string FirstName { get; set; } = "";

    public string LastName { get; set; } = "";

    public bool IsAdmin { get; set; }
}
