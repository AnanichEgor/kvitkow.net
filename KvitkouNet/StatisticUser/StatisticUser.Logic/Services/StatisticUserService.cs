using System.Collections.Generic;
using System.Threading.Tasks;
using StatisticUser.Logic.DTOs;
using StatisticUser.Logic.Interfaces;

namespace StatisticUser.Logic.Services
{
    public class StatisticUserService: IStatisticUserService
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ITimeOnResouces>> GetTimeOnResouces(DateRange filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IUserOnline> GetUserOnline(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IUserRating> GetUserRating(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IRegistrationTime>> GetRegistrationsTime(DateRange filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IUserMessages> GetUserMessages(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}