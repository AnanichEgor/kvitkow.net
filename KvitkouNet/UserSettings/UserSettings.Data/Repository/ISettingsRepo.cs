﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserSettings.Data.DbModels;

namespace UserSettings.Data
{
	public interface ISettingsRepo
	{
		Task<SettingsDb> Get(string id);

		/// <summary>
		/// Обновление информации о том какие уведомления получать 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="notifications"></param>
		/// <returns></returns>
		Task<bool> UpdateNotifications(string id, NotificationDb notifications);

		/// <summary>
		/// Обновление предпочтений по отображению информации
		/// </summary>
		/// <param name="id"></param>
		/// <param name="address"></param>
		/// <param name="region"></param>
		/// <param name="place"></param>
		/// <returns></returns>
		Task<bool> UpdatePreferences(string id, string address, string region, string place);

		/// <summary>
		/// Удаление аккаунта
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Task DeleteAccount(string id);

		/// <summary>
		/// Обновление информации о том какая информация о пользователе доступна для при просмотре профиля
		/// </summary>
		/// <param name="id"></param>
		/// <param name="visibleInfoDb"></param>
		/// <returns></returns>
		Task<bool> UpdateVisible(string id, VisibleInfoDb visibleInfoDb);
	}
}
