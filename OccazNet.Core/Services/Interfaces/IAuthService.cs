using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccazNet.Core.Models.Users;
using OccazNet.Core.Services.Imlementations;

namespace OccazNet.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult> RegisterAsync(Register register);
        Task<ServiceResult> LoginAsync(Login login);
    }
}
