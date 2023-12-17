using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Application;

public class Application
{
    public Application()
    {
        ApplicationLicences = new List<ApplicationLicences>();
    }

    [JsonIgnore]
    public int Id { get; set; }

    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<ApplicationLicences> ApplicationLicences { get; set; }
}