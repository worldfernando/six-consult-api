using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SixConsultApi.Dto.Profile
{
    public class ProfileDto: Dto
    {
        public string Name { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool IsAdmin { get; set; }

        public ProfileDto(string name, bool create, bool update, bool delete, bool isAdmin)
        {
            this.Name = name;
            this.Create = create;
            this.Update = update;
            this.Delete = delete;
            this.IsAdmin = isAdmin;
        }
    }
}
