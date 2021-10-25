using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocuraeAPI.Repositories
{
    public interface ILoginRepository
    {
        Task SetNewUserAsync();
    }
}
