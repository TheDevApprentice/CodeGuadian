using CodeGuardian.DOMAIN.Entity.Application;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class License
{
    [JsonIgnore]
    public int Id { get; set; }

    public Guid Uuid { get; set; } = Guid.NewGuid();

    public string Status { get; set; } = "Inactive";

    public string KeyHash { get; set; }

    public int ApplicationId { get; set; }

    [JsonIgnore]
    public Application Application { get; set; }
}