using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Kafka;
using Microsoft.Extensions.Logging;

namespace FunctionAppKafka
{
    public static class ConsumerKafka
    {
        [FunctionName("ConsumerKafka")]
        public static void Run([KafkaTrigger(
            "BrokerKafka", "topic-azure-functions",
            ConsumerGroup = "topic-azure-functions-group")]KafkaEventData<string> kafkaEvent,
            ILogger log)
        {
            log.LogInformation("Azure Functions + Apache Kafka | " +
                $"Mensagem recebida: {kafkaEvent.Value.ToString()}");
        }
    }
}