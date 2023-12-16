using CodeGuardian.DOMAINE.Entity;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Application;

public class ApplicationLicences
{
    [JsonIgnore]
    public int ApplicationId { get; set; }

    public int LicenceID { get; set; }

    [JsonIgnore]
    public Application Application { get; set; }

    [JsonIgnore]
    public License Licence { get; set; }
}