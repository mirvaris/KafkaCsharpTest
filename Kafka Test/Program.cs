using RdKafka;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafkaCsharpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            KafkaTester().Wait();
        }

        static async Task KafkaTester()
        {
            using (Producer producer = new Producer("127.0.0.1:9092"))
            using (Topic topic = producer.Topic("test"))
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello RdKafka");
                DeliveryReport deliveryReport = await topic.Produce(data);
                Console.WriteLine($"Produced to Partition: {deliveryReport.Partition}, Offset: {deliveryReport.Offset}");
            }

            Console.ReadLine();
        }
    }
}
