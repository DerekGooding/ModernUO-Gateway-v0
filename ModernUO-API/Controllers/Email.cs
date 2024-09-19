using Microsoft.AspNetCore.Mvc;

namespace ModernUO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class Email : Controller
{
    [HttpGet]
    public ActionResult<string> GetUsers() => "placeholder email";
}
