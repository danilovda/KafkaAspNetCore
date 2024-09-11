using Confluent.Kafka;

namespace KafkaConsumerApi.Extensions;

internal static class KafkaConsumerExtensions
{
    internal static IServiceCollection AddKafkaConsumer(this IServiceCollection services, IConfiguration configuration)
    {        
        var kafkaConfig = configuration.GetSection("Kafka");
        
        services.AddSingleton<IConsumer<Null, string>>(sp =>
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = kafkaConfig["BootstrapServers"],
                GroupId = kafkaConfig["GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            return new ConsumerBuilder<Null, string>(config).Build();
        });

        return services;
    }
}