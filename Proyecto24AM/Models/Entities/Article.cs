using System.ComponentModel.DataAnnotations;

namespace Proyecto24AM.Models.Entities
{
    public class Article
    {
        [Key]public int PKArticle { get; set; }
        [Required]public string Name { get; set; }
        [Required] public string Description { get; set; }
        [Required] public double Price { get; set; }
    }
}
