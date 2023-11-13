using System.ComponentModel.DataAnnotations;

namespace Proyecto24AM.Models.Entities
{
    public class Book
    {
        [Key] public int PKBook { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Description { get; set; }
        [Required] public string Images { get; set; }
        [Required] public bool Active { get; set; }
    }
}