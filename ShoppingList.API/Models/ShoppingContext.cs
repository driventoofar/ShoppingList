using Microsoft.EntityFrameworkCore;

namespace ShoppingList.API.Models
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options)
            : base(options)
        {
        }

        public DbSet<ListItem> ShoppingList { get; set; }
    }
}
