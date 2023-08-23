using FundooNoteSubscriber.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace FundooNoteSubscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("D:\\Project\\FirstProject\\FundooNoteSubscriber\\appsettings.json", optional: false)
                .Build();

            var factory = new ConnectionFactory
            {
                HostName = configuration["RabbitMQSettings:HostName"],
                UserName = configuration["RabbitMQSettings:UserName"],
                Password = configuration["RabbitMQSettings:Password"]
            };

            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(configuration["RabbitMQSettings:HostName"]), h =>
                {
                    h.Username(configuration["RabbitMQSettings:UserName"]);
                    h.Password(configuration["RabbitMQSttings:Password"]);
                });

                //Automatically register the consumer
                cfg.ReceiveEndpoint("User-Registration-Queue", e =>
                {
                    //Automatically Register the consumer using the DI container
                    e.Consumer<UserRegistrationEmailSubscriber>();
                });
            });

            var subscriber = new RabbitMQSubscriber(factory, configuration, busControl);
            subscriber.ConsumeMessages();

            Console.WriteLine("Press any key to exit......");
            Console.ReadKey();
        }
    }
}
