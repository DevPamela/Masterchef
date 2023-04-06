using MasterChef.Api.Models;
using Masterchef.Domain;
using Microsoft.EntityFrameworkCore;

namespace MasterChef.Persistence
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        { }


        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}