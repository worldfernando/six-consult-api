using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Domain.Entities
{
    public class Profile : Entity
    {
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool IsAdmin { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public Profile(string name, bool create, bool update, bool delete, bool isAdmin)
        {
            this.Name = name;
            this.Create = create;
            this.Update = update;
            this.Delete = delete;
            this.IsAdmin = isAdmin;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

        public Profile(long id, string name, bool create, bool update, bool delete, bool isAdmin)
        {
            this.Id = id;
            this.Name = name;
            this.Create = create;
            this.Update = update;
            this.Delete = delete;
            this.IsAdmin = isAdmin;
            this.CreatedAt = DateTime.Now;
            this.UpdatedAt = DateTime.Now;
        }

    }
}
