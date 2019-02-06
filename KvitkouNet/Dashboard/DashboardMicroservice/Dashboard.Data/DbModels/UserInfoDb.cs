using System.Collections.Generic;

namespace Dashboard.Data.DbModels
{
    public class UserInfoDb
    {
        /// <summary>
        ///     Id юзера
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        ///     Имя юзера
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     Фамилия юзера
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     Gets or sets the user rating.
        /// </summary>
        public double? Rating { get; set; }
        
        #region Связи между таблицами 
        /// <summary>
        ///     Новость
        /// </summary>
        public virtual NewsDb NewsDbs { get; set; }
        #endregion 
    }
}
