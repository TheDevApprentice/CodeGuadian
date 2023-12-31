using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CodeGuardian.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VersionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public VersionController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Route to obtain the api version
    /// </summary>
    /// <returns></returns>
    [HttpGet("getversion")]
    public string GetVersion()
    {
        Version version = Assembly.GetEntryAssembly().GetName().Version;
        return version.ToString();
    }
}