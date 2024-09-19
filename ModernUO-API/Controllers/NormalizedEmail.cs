using Microsoft.AspNetCore.Mvc;

namespace ModernUO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NormalizedEmail : Controller
{
    [HttpGet]
    public ActionResult<int> GetUsers() => 3;
}
