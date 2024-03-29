﻿using Microsoft.AspNetCore.Mvc;

namespace Tellurian.WagonCardApp.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    public readonly IContentService Service;
    public ContentController(IContentService service) => Service = service;

    [HttpGet("{content}")]
    public async Task<IActionResult> GetContent(string content)
    {
        var result = await Service.GetTextContent(content);
        return result is null ? NotFound() : Ok(result);
    }
}
