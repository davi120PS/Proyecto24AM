using System.ComponentModel.DataAnnotations;

namespace Proyecto24AM.Models.Entities
{
    public class Rol
    {
        [Key] public int PKRol { get; set; }
        [Required] public string Name { get; set;}

    }
}
