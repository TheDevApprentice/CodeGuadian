using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.PowerUser;

public class PowerUserApplication
{
    [JsonIgnore]
    public int ApplicationId { get; set; }

    public int PowerUserId { get; set; }

    [JsonIgnore]
    public Application.Application Application { get; set; }

    [JsonIgnore]
    public PowerUser PowerUser { get; set; }
}