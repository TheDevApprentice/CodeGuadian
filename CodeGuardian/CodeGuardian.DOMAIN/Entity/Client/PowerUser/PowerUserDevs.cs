using CodeGuardian.DOMAIN.Entity.Users.Dev;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.PowerUser;

public class PowerUserDevs
{
    [JsonIgnore]
    public int DevelopperId { get; set; }

    public int PowerUserId { get; set; }

    [JsonIgnore]
    public Dev Developper { get; set; }

    [JsonIgnore]
    public PowerUser Poweruser { get; set; }
}