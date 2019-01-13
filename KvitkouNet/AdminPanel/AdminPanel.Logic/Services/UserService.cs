using System.Threading.Tasks;
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

		public async Task Ban(int id)
		{
			throw new System.NotImplementedException();
		}

		public async Task Unban(int id)
		{
			throw new System.NotImplementedException();
		}
	}
}