using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using KvitkouNet.Messages.UserManagement;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace UserManagement.Logic.Subscriber
{
    public static class SubscriberExtensions
    {
        public static IApplicationBuilder UseSubscriber(this IApplicationBuilder app, string prefix,
            params Assembly[] assembly)
        {
            var services = app.ApplicationServices.CreateScope().ServiceProvider;

            var lifetime = services.GetService<IApplicationLifetime>();
            var bus = services.GetService<IBus>();

            lifetime.ApplicationStarted.Register(() =>
            {
                //var subscriber = new AutoSubscriber(bus, prefix);
                //subscriber.Subscribe(assembly);
                //subscriber.SubscribeAsync(assembly);
                //bus.SubscribeAllConsumers(services);
                bus.SubscribeAsync<AccountMessage>("UserService.AccountCreated", msg => services.GetService<IConsumeAsync<AccountMessage>>().ConsumeAsync(msg));
            });

            lifetime.ApplicationStopped.Register(() => bus.Dispose());

            return app;
        }
    }
}

