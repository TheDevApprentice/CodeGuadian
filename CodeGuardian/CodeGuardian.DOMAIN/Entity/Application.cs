using System.ComponentModel;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace CodeGuardian.DOMAINE.Entity;

public class Application
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<License> Licenses { get; set; }
}