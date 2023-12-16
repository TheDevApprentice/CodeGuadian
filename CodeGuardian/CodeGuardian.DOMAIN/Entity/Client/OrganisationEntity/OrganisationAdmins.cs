using CodeGuardian.DOMAIN.Entity.Users.Admin;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

public class OrganisationAdmin
{
    [JsonIgnore]
    public int AdminId { get; set; }

    public int OrganisationId { get; set; }

    [JsonIgnore]
    public Administrator Admin { get; set; }

    [JsonIgnore]
    public Organisation Organisation { get; set; }
}