using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;

namespace KafkaProducerApi.Controllers;

public class ProducerController(IProducer<Null, string> producer) : Controller
{
    private readonly IProducer<Null, string> _producer = producer;

    [HttpPost("send")]
    public async Task<IActionResult> SendMessage([FromBody] string message)
    {
        var kafkaMessage = new Message<Null, string> { Value = message };
        var deliveryResult = await _producer.ProduceAsync("test-topic", kafkaMessage);

        return Ok($"Message '{deliveryResult.Value}' was sent to '{deliveryResult.TopicPartitionOffset}'");
    }
}
