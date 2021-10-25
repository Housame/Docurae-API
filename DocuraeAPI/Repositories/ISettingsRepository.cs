using DocuraeAPI.Models;
using DocuraeAPI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Repositories
{
    public interface ISettingsRepository
    {
        Task<SettingsDTO> GetSettingsAsync();
    }
}
