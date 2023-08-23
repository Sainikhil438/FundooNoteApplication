﻿using FundooNoteSubscriber.Interface;
using FundooNoteSubscriber.Models;
using MassTransit;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FundooNoteSubscriber.Services
{
    public class RabbitMQSubscriber : IRabbitMQSubscriber
    {
        private readonly ConnectionFactory factory;
        private readonly IConfiguration configuration;
        private readonly IBusControl _busControl; //Add this to inject MassTransit bus

        public RabbitMQSubscriber(ConnectionFactory _factory, IConfiguration _configuration, IBusControl busControl)
        {
            factory = _factory;
            configuration = _configuration;
            _busControl = busControl;   //Inject the Mass Transit Bus

            ConsumeMessages();
        }

        public void ConsumeMessages()
        {
            using(var connection = factory.CreateConnection())
            {
                Console.WriteLine("Connection to RabbitMQ server established");

                using (var channel  = connection.CreateModel())
                {
                    var queueName = "User-Registration-Queue";
                    channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);

                        //Send the received email to the UserRegistrationEmailSubscriber consumer
                        await _busControl.Publish<UserRegistrationMessage>(new
                        {
                            Email = message
                        });
                    };

                    channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                }
            }
        }
    }
}
