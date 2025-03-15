using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccazNet.Application.Dtos.Users.Request;
using OccazNet.Application.Dtos.Users.Response;
using OccazNet.Core.Services.Imlementations;

namespace OccazNet.Core.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult<AuthResp>> RegisterAsync(Register register);
        Task<ServiceResult<AuthResp>> LoginAsync(Login login);
        Task<ServiceResult<AuthResp>> RefreshTokenAsync( string refreshToken);
    }
}
