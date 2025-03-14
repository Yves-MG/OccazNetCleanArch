using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccazNet.Core.Services.Interfaces;

namespace OccazNet.Core.Services.Imlementations
{
    public class ServiceResult : IServiceResult
    {
        public bool IsSuccess { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public ServiceResult(bool isSuccess, string message, object data = null)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
        }

        public static IServiceResult Failure(string message)
        {
            return new ServiceResult(false, message);
        }

        public static IServiceResult Success(string message,object data = null)
        {
            return new ServiceResult(true, message, data);
        }
    }
}
