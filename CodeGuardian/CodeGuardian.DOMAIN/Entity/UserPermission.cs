using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class UserPermission
{
    [JsonIgnore]
    public int UserId { get; set; }

    public Guid userPermissionUuid { get; set; }

    public int PermissionId { get; set; }

    [JsonIgnore]
    public User User { get; set; }

    [JsonIgnore]
    public Permission Permission { get; set; }
}