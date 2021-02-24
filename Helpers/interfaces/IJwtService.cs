using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Helpers.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(string secret, string claimId);
    }
}
