using System;
using System.Collections.Generic;
using System.Text;

namespace Cloud_Custom.Api.Infrastructure.ISecurity
{
   public interface IHash
    {
        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt);
        public bool ComparePasswordHash(string password, string storedHash, string storedSalt);
    }
}
