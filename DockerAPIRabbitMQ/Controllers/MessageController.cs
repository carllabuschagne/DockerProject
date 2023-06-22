using DockerAPIDataModels.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;


namespace DockerAPIMembers.Controllers
{
    [Authorize]
    [Route("message/send")]
    [ApiController]
    public class MessageSendController : ControllerBase
    {
        public IConfiguration _configuration;

        public MessageSendController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get(string text)
        {
            var factory = new ConnectionFactory
            {
                HostName = "20.164.202.61",
                Port = 5672,
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = text;
            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: string.Empty,
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);

            return Ok();
        }
    }


    [Authorize]
    [Route("message/get")]
    [ApiController]
    public class MessageReceiveController : ControllerBase
    {
        public IConfiguration _configuration;

        public MessageReceiveController(IConfiguration config)
        {
            _configuration = config;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var factory = new ConnectionFactory
            {
                HostName = "20.164.202.61",
                Port = 5672,
                DispatchConsumersAsync = true
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (o, eventArgs) =>
                    {
                        var body = eventArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                    };
                }

            }
            return Ok("done");
        }
    }


}