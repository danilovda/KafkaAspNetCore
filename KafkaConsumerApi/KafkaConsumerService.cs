using Confluent.Kafka;

namespace KafkaConsumerApi;

internal class KafkaConsumerService(IConsumer<Null, string> consumer) : BackgroundService
{
    private readonly IConsumer<Null, string> _consumer = consumer;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe("test-topic");

        while (!stoppingToken.IsCancellationRequested)
        {
            var consumeResult = _consumer.Consume(stoppingToken);
            Console.WriteLine($"Received message: {consumeResult.Message.Value}");
        }

        _consumer.Close();
    }
}