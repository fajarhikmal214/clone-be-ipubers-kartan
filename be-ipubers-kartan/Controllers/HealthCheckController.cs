using Microsoft.AspNetCore.Mvc;

namespace be_ipubers_kartan.Controllers;

[ApiController]
[Route("/healthcheck")]
public class HealthCheckController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public HealthCheckController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    [Route("")]
    public IActionResult Get()
    {
        var app = _configuration["AppSettings:AppName"] ?? "ipubers-kartan-api";
        var environment = _configuration["AppSettings:EnvironmentName"] ?? "Unknown";

        return Ok(new
        {
            app,
            environment,
            status = "Healthy"
        });
    }
}