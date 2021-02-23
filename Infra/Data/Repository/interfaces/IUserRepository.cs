using SixConsultApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Infra.Data.Repository.interfaces
{
    interface IUserRepository : IRepository<User>
    {
        User GetByEmailAndPassword(string email, string password);
    }
}
