using System.ComponentModel.DataAnnotations;
using Masterchef.Domain;

namespace MasterChef.Api.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Foto { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public List<Tags> Tags { get; set; } = new List<Tags>();

        public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();

        public List<PrepareModes> PrepareModes { get; set; } = new List<PrepareModes>();

        public Category Category { get; set; } = new Category();
    }
}