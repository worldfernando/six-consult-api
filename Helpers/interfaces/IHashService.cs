using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Helpers.Interfaces
{
    interface IHashService
    {
        string HashPassword(string password);

        bool Verify(string password, string passwordHash);
    }
}
