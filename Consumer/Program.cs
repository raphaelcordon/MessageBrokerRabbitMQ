using Consumer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IRabbitMqConsumerService, RabbitMqConsumerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var consumerService = app.Services.GetRequiredService<IRabbitMqConsumerService>();
consumerService.StartConsumer();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();