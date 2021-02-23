using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Helpers.Interfaces
{
    interface IJwtService
    {
        string GenerateJwtToken(string secret, string claimId);
    }
}
