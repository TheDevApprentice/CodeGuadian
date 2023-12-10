using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class License
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }

    public Application Application { get; set; }
}