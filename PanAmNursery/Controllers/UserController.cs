using Microsoft.AspNetCore.Mvc;
using PanAmNursery.Dtos;
using PanAmNursery.Services.Interfaces;
using System.Text.Json;

namespace PanAmNursery.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    private readonly ILogger<UserController> _logger;

    public UserController(IUserService service, ILogger<UserController> logger)
    {
        _service = service;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
    {
        _logger.LogInformation("POST /api/users called with dto={DTO}", JsonSerializer.Serialize(dto));
        var created = await _service.CreateUserAsync(dto);
        return CreatedAtAction(nameof(GetUser), new { id = created.Id }, created);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        _logger.LogInformation("GET /api/users/{Id} called", id);
        var user = await _service.GetUserAsync(id);
        return (user == null) ? NotFound() : Ok(user);
    }
}
