using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class UserApplications
{
    [JsonIgnore]
    public int UserId { get; set; }

    public int ApplicationId { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    [JsonIgnore]
    public Application Application { get; set; }
}