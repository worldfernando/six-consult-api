using System;

namespace SixConsultApi.Helpers
{
    public class SixBusinessException : Exception
    {
        public SixBusinessException(string message) : base(message)
        {

        }
    }
}
