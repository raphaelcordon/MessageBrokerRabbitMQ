using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

public interface IRabbitMqConsumerService
{
    void StartConsumer();
}

public class RabbitMqConsumerService : IRabbitMqConsumerService
{
    private readonly ConnectionFactory _factory;

    public RabbitMqConsumerService(IConfiguration configuration)
    {
        _factory = new ConnectionFactory
        {
            HostName = configuration["RabbitMQ:HostName"],
            UserName = configuration["RabbitMQ:UserName"],
            Password = configuration["RabbitMQ:Password"]
        };
    }

    public void StartConsumer()
    {
        var connection = _factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare("userQueue", false, false, false, null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            // Process the message
        };

        channel.BasicConsume(queue: "userQueue", autoAck: true, consumer: consumer);
    }
}
