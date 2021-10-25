using DocuraeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Repositories
{
    public interface ILogTextRepository
    {
        Task<IEnumerable<TextLogDTO>> GetLogTextsAsync(int patientId);
        Task SetLogTextAsync(AddTextLogDTO newTextLog, int patientId);
        Task SetReminderAsync(AddReminderDTO obj);
        Task SetNewAdditionAsync(AddTextLogAdditionsDTO lTAdditionsObj);
        Task DeleteTextLogAsync(int textLogID);
    }
}
