﻿#region

using Topshelf;

#endregion

namespace KafkaService
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<KafkaServiceWrapper>(s =>
                {
                    s.ConstructUsing(instance => new KafkaServiceWrapper());
                    s.WhenStarted(instance => instance.Start());
                    s.WhenStopped(instance => instance.Stop());
                });

                x.RunAsLocalSystem();
                x.StartAutomatically();

                x.SetDescription("Wrapper around Apache Kafka for starting and stopping both Zookeeper and Kafka.");
                x.SetDisplayName("Kafka.Service");
                x.SetServiceName("Kafka.Service");
            });
        }
    }
}