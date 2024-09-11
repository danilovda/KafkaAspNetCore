using Confluent.Kafka;

namespace KafkaProducerApi.Extensions;

internal static class KafkaProducerExtensions
{
    internal static IServiceCollection AddKafkaProducer(this IServiceCollection services, IConfiguration configuration)
    {
        var kafkaConfig = configuration.GetSection("Kafka");
        
        services.AddSingleton<IProducer<Null, string>>(sp =>
        {
            var config = new ProducerConfig
            {
                BootstrapServers = kafkaConfig["BootstrapServers"]
            };
            return new ProducerBuilder<Null, string>(config).Build();
        });

        return services;
    }
}
