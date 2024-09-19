using Microsoft.AspNetCore.Mvc;

namespace ModernUO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailConfirmed : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<string>> GetUsers() => new string[] { "User1", "User2", "User3" };
}
