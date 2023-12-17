using CodeGuardian.DOMAIN.Entity.Users.Dev;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

public class OrganisationDevs
{
    [JsonIgnore]
    public int DevelopperId { get; set; }

    public int OrganisationId { get; set; }

    [JsonIgnore]
    public Dev Developper { get; set; }

    [JsonIgnore]
    public Organisation Organisation { get; set; }
}