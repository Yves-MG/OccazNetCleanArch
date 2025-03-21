﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OccazNet.Core.Entities;

namespace OccazNet.Core.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User userName);
        string GenerateRefreshToken();

    }
}
