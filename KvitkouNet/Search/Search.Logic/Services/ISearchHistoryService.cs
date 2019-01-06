﻿using System;
using System.Threading.Tasks;
using Search.Data.Models;

namespace Search.Logic.Services
{
    public interface ISearchHistoryService : IDisposable
    {
        /// <summary>
        /// Gets the last search by <see cref="userId"/>.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        Task<SearchEntity> GetLastSearch(string userId);
    }
}
