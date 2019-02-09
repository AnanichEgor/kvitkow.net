using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
                var subscriber = new AutoSubscriber(bus, prefix);
                subscriber.Subscribe(assembly);
                subscriber.SubscribeAsync(assembly);
            });

            lifetime.ApplicationStopped.Register(() => bus.Dispose());

            return app;
        }
    }
}
