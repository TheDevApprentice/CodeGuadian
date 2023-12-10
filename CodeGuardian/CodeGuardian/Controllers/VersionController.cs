using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CodeGuardian.API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class VersionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public VersionController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet("getversion")]
    public string GetVersion()
    {
        Version version = Assembly.GetEntryAssembly().GetName().Version;

        return version.ToString();
    }
}