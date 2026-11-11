
using Cloud_Custom.Api.Shared.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Repository.IRepository.Account
{
  public  interface ITokenRepository
    {
         string GenerateToken<T>(AppTokenSettings<T> tokenSettings);
    }
}
