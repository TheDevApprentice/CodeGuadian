using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class Application
{
    [JsonIgnore]
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public List<License> Licenses { get; set; }
}