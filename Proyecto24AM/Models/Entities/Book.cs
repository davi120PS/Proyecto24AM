using System.ComponentModel.DataAnnotations;

namespace Proyecto24AM.Models.Entities
{
    public class Book
    {
        [Key] public int PKBook { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
    }
}
