using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Logic.Models;
using Security.Logic.Models.Enums;
using Security.Logic.Models.Responses;

namespace Security.Logic.Services
{
    /// <summary>
    /// Сервис для работы с сущностями Security
    /// </summary>
    public interface IFeatureService : IDisposable
    {
        /// <summary>
        /// Получение списка фич
        /// </summary>
        /// <returns></returns>
        Task<FeatureResponse> GetFeatures(int itemsPerPage, int pageNumber, string mask = null);

        /// <summary>
        /// Добавление фичи
        /// </summary>
        /// <param name="feature">Добавляемая фича</param>
        /// <returns></returns>
        Task<ActionResponse> AddFeature(Feature feature);

        /// <summary>
        /// Удаление фичи
        /// </summary>
        /// <param name="featureId">Идентификатор фичи</param>
        /// <returns></returns>
        Task<ActionResponse> DeleteFeature(int featureId);

        /// <summary>
        /// Изменение фичи
        /// </summary>
        /// <param name="feature">Изменяемая фича</param>
        /// <returns></returns>
        Task<ActionResponse> EditFeature(Feature feature);
    }
}
