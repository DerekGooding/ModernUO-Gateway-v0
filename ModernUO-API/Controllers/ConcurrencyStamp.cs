using Microsoft.AspNetCore.Mvc;

namespace ModernUO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConcurrencyStamp : Controller
{
    [HttpGet]
    public ActionResult<string> GetUsers() => "placeholder stamp";
}
