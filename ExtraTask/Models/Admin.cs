using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ExtraTask.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Admin> Admins { get; set; }
        public Role()
        {
            Admins = new List<Admin>();
        }
    }
}
