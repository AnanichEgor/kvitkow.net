using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Search.Web.Subscriber
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
                var subscriber = new AutoSubscriber(bus, prefix)
                {
                    AutoSubscriberMessageDispatcher = new MessageDispatcher(app.ApplicationServices)
                };
                subscriber.Subscribe(assembly);
                subscriber.SubscribeAsync(assembly);
            });

            lifetime.ApplicationStopped.Register(() => bus.Dispose());

            return app;
        }
    }
}
