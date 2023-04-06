using System.ComponentModel.DataAnnotations;

namespace MasterChef.Api.Models
{
    public class Tags
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}