using CodeGuardian.DOMAIN.Entity.Users.Admin;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.PowerUser;

public class PowerUserAdmins
{
    [JsonIgnore]
    public int AdmininistatorId { get; set; }

    public int PowerUserId { get; set; }

    [JsonIgnore]
    public Administrator Admininistrator { get; set; }

    [JsonIgnore]
    public PowerUser Poweruser { get; set; }
}