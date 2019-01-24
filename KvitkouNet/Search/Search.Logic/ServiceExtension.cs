using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Search.Data.Models;
using Search.Logic.Common.Models;
using Search.Logic.Services;

namespace Search.Logic
{
    public static class ServiceExtension
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISearchUserService, SearchUserService>();
            services.AddScoped<ISearchTicketService, SearchTicketService>();
            services.AddScoped<ISearchHistoryService, SearchHistoryService>();
            return services;
        }

        private static Mock<ISearchUserService> GetUserSearchMock()
        {
            var mock = new Mock<ISearchUserService>();
            var result = new SearchResult<UserInfo>
            {
                Items = Enumerable.Empty<UserInfo>(),
                Total = 10
            };
            mock.Setup(service => service.Search(It.IsAny<UserSearchRequest>())).ReturnsAsync(result);

            return mock;
        }

        private static Mock<ISearchTicketService> GetTicketSearchMock()
        {
            var mock = new Mock<ISearchTicketService>();
            var result = new SearchResult<TicketInfo>
            {
                Items = Enumerable.Empty<TicketInfo>(),
                Total = 10
            };
            mock.Setup(service => service.Search(It.IsAny<TicketSearchRequest>())).ReturnsAsync(result);

            return mock;
        }

        private static Mock<ISearchHistoryService> GetLastSearchMock()
        {
            var mock = new Mock<ISearchHistoryService>();
            var result = new TicketSearchEntity
            {
                SearchTime = new DateTime(2018, 1, 6, 21, 58, 10),
                UserId = "1",
                Id = 1
            };
            mock.Setup(service => service.GetLastSearch(It.IsAny<string>())).ReturnsAsync(result);

            return mock;
        }
    }
}
