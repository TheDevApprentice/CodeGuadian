using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class License
{
    [JsonIgnore]
    public int Id { get; set; }

    public Guid Uuid { get; set; }

    public string Status { get; set; }

    public string Key { get; set; }

    public int ApplicationId { get; set; }

    public Application Application { get; set; }
}