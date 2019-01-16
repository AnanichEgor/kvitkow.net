using System.Threading.Tasks;
using AdminPanel.Logic.Dtos.UserManagement;
using AdminPanel.Logic.Infrastructure;
using AdminPanel.Logic.Models.UserManagement;

namespace AdminPanel.Logic.Services
{
	public class UserService : IUserService
	{
		public async Task<User> GetAll()
		{
			throw new System.NotImplementedException();
		}

		public Task ChangeIsBannedStatus(IsBannedDto dto)
		{
			throw new System.NotImplementedException();
		}
	}
}