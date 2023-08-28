using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Services
{
    public class MessageService
    {
        private readonly ServiceBusClient _client; 
        private readonly ServiceBusSender _sender; 
        private readonly IConfiguration _configuration; 
        public MessageService(IConfiguration configuration) 
        {
            this._configuration = configuration; 
            string connectionString = ""; 
            string queueName = ""; 
            _client = new ServiceBusClient(connectionString); 
            _sender = _client.CreateSender(queueName); 
        }
        public void SendMessage2Queue(string email, string token) 
        {
            string messageBody = $"Token : {token}"; 
            ServiceBusMessage message = new ServiceBusMessage(); 
            message.Subject = "Reset Token"; 
            message.To = email; 
            message.Body = BinaryData.FromString(messageBody); 
            _sender.SendMessageAsync(message).Wait(); 
        } 
    }
}
