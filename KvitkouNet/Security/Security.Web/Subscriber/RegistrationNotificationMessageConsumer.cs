using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using Microsoft.Extensions.Configuration;
using Security.Data.ConfigModels;
using Security.Logic.Services;

namespace Security.Web.Subscriber
{
    public class RegistrationNotificationMessageConsumer : IConsumeAsync<RegistrationMessage>
    {
        private IUserRightsService m_service;
        private IConfiguration m_config;

        public RegistrationNotificationMessageConsumer(IUserRightsService service, IConfiguration config)
        {
            m_service = service;
            m_config = config;
        }

        [AutoSubscriberConsumer(SubscriptionId = "RegistrationMessage")]
        public async Task ConsumeAsync(RegistrationMessage message)
        {
            //var senderConfig = m_config.GetSection("SenderConfig").Get<DefaultRulesAll>();
            //SendEmailRequest request = new SendEmailRequest
            //{
            //    ReceiverEmail = message.Name,
            //    ReceiverName = message.Email,
            //    Subject = "Подтверждение регистрации",
            //    Text = $"Для подтверждения регистрации прейдите по ссылке {m_config[$"RegistrationUrl"]}/{message.Name}"
            //};

            //await m_service.SendRegistrationNotification(request);
        }
    }
}
