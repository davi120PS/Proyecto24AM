using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto24AM.Models.Entities
{
    public class User
    {
        [Key]public int PKUser { get; set; }
        public string Name { get; set; }
        public string lastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("Roles")] public int FKRol { get; set; }
        public Rol Roles { get; set; }
    }
}
