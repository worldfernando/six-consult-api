using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Helpers
{
    public class SixTools
    {
        private IHttpContextAccessor _httpContextAccessor;
        public SixTools(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUserTokenId()
        {
            var authenticateInfo = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault().Value;
            return int.Parse(authenticateInfo);
        }

        public string GetUserIp()
        {
            var ip = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return ip;
        }
    }
}
