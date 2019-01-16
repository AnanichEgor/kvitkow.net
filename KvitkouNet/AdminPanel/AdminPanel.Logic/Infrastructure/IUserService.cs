using System.Threading.Tasks;
using AdminPanel.Logic.Dtos.UserManagement;
using AdminPanel.Logic.Models.UserManagement;

namespace AdminPanel.Logic.Infrastructure
{
	/// <summary>
	/// Сервис для работы с пользователями через панель администратора
	/// </summary>
	public interface IUserService
	{
		Task<User> GetAll();

		Task ChangeIsBannedStatus(IsBannedDto dto);
	}
}