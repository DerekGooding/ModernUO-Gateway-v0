﻿using Microsoft.AspNetCore.Mvc;

namespace ModernUO_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PasswordHash : Controller
{
    [HttpGet]
    public ActionResult<int> GetUsers() => 3;
}
