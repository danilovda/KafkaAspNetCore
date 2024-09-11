using Confluent.Kafka;
using KafkaConsumerApi;
using KafkaConsumerApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Configuration of the Kafka consumer
builder.Services.AddKafkaConsumer(builder.Configuration);

// Adding the background service of the consumer
builder.Services.AddHostedService<KafkaConsumerService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
