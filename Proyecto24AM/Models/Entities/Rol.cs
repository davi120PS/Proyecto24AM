using System.ComponentModel.DataAnnotations;

namespace Proyecto24AM.Models.Entities
{
    public class Rol
    {
        [Key] public int PKRol { get; set; }
        public string Name { get; set;}

    }
}
