using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Client.OrganisationEntity;

public class OrganisationApplication
{
    [JsonIgnore]
    public int ApplicationId { get; set; }

    public int OrganisationId { get; set; }

    [JsonIgnore]
    public Application.Application Application { get; set; }

    [JsonIgnore]
    public Organisation Organisation { get; set; }
}