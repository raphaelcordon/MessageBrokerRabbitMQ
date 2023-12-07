using System.Text;
using System.Text.Json;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;

namespace Producer.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IRabbitMqService _rabbitMqService;

    public UserController(IRabbitMqService rabbitMqService)
    {
        _rabbitMqService = rabbitMqService;
    }

    [HttpPost]
    public IActionResult Post()
    {
        var user = new User("Raphael", "raphael@email.com");
        _rabbitMqService.SendMessage(user);
        return Ok();
    }
}