using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Masterchef.Domain
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }
}