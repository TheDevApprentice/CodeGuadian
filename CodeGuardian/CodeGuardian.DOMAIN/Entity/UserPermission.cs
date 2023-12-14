using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class UserPermission
{
    [JsonIgnore]
    public int UserId { get; set; }

    public Guid userPermissionUuid { get; set; }

    public int PermissionId { get; set; }

    [JsonIgnore]
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public User User { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.

    [JsonIgnore]
#pragma warning disable CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
    public Permission Permission { get; set; }
#pragma warning restore CS8618 // Un champ non-nullable doit contenir une valeur non-null lors de la fermeture du constructeur. Envisagez de déclarer le champ comme nullable.
}