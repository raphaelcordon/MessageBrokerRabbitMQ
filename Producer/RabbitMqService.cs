using System.Text;
using Core.Entities;
using RabbitMQ.Client;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Producer;

public interface IRabbitMqService
{
    void SendMessage(User user);
}

public class RabbitMqService : IRabbitMqService
{
    private readonly ConnectionFactory _factory;

    public RabbitMqService(IConfiguration configuration)
    {
        _factory = new ConnectionFactory 
        { 
            HostName = configuration["RabbitMQ:HostName"], 
            UserName = configuration["RabbitMQ:UserName"], 
            Password = configuration["RabbitMQ:Password"]
        };
    }

    public void SendMessage(User user)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();
        channel.QueueDeclare("userQueue", false, false, false, null);

        var message = JsonSerializer.Serialize(user);
        var body = Encoding.UTF8.GetBytes(message);
        channel.BasicPublish("", "userQueue", null, body);
    }
}
