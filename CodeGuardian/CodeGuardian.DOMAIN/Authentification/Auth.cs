using CodeGuardian.DOMAINE.Authentification;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CodeGuardian.API.Controllers
{
    public class Auth : IAuthService
    {
        private string _connectionString;

        public string GenerateJwtToken(string user, string role, string audiance = "your-audience", string issuer = "your-issuer")
        {
            string configuration = ExtractConfiguration("select value from SecurityConfiguration where name = 'secretKey'");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user),
                    new Claim(ClaimTypes.Role, role),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateJwtTokenApplication(string applicationUuidEncrypted, string role, string audiance = "your-audience", string issuer = "your-issuer")
        {
            string configuration = ExtractConfiguration("select value from SecurityConfiguration where name = 'secretKey");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = audiance,
                Issuer = issuer,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, applicationUuidEncrypted),
                    new Claim(ClaimTypes.Role, role),

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        public DataTable DatabaseOperation(string query)
        {
            _connectionString = "Server=host.docker.internal;Database=myDatabase;User=root;Password=myPassword;";

            DatabaseController databaseController = new DatabaseController(_connectionString);
            return databaseController.ExecuteQuery(query);
        }

        public string ExtractConfiguration(string query)
        {
            string configuration = "";

            DataTable result = DatabaseOperation(query);

            if (result.Rows.Count > 0)
            {
                DataRow firstRow = result.Rows[0];

                if (result.Columns.Contains("value"))
                {
                    object valueObject = firstRow["value"];

                    if (valueObject != DBNull.Value)
                    {
                        configuration = valueObject.ToString();
                    }
                }
            }

            return configuration;
        }
    }
}

public class DatabaseController
{
    private readonly string _connectionString;

    public DatabaseController(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable ExecuteQuery(string query)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            connection.Open();

            using (var command = new MySqlCommand(query, connection))
            {
                var dataTable = new DataTable();
                using (var dataAdapter = new MySqlDataAdapter(command))
                {
                    dataAdapter.Fill(dataTable);
                }

                return dataTable;
            }
        }
    }
}