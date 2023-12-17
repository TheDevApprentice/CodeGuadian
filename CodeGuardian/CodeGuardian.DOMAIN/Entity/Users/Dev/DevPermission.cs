using CodeGuardian.DOMAINE.Entity;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAIN.Entity.Users.Dev;

public class DevPermission
{
    [JsonIgnore]
    public int DevId { get; set; }

    public Guid DevPermissionUuid { get; set; } = Guid.NewGuid();

    public int PermissionId { get; set; }

    [JsonIgnore]
    public Dev Dev { get; set; }

    [JsonIgnore]
    public Permission Permission { get; set; }
}