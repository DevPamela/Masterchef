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

        public int Tags { get; set; }

        public string Description { get; set; } = string.Empty;

        public List<Ingredients> Ingredients { get; set; }

        public List<PrepareModes> PrepareModes { get; set; }

        public Category Category { get; set; }
    }
}