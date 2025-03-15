using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OccazNet.Core.Services.Interfaces
{
    public interface IServiceResult<T> 
    {
        bool IsSuccess { get; }
        string Message { get; }
        T  Data { get; }
    }
}
