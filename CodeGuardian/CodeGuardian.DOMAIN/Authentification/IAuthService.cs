using System.Data;

namespace CodeGuardian.DOMAINE.Authentification
{
    public interface IAuthService
    {
        DataTable DatabaseOperation(string query);
        string ExtractConfiguration(string query);
        string GenerateJwtToken(string user, string role, string audiance = "your-audience", string issuer = "your-issuer");
    }
}