using PGEFExample.Models;
using Microsoft.EntityFrameworkCore;
namespace PGEFExample.Data;

public class ProductsContext : DbContext{
    public DbSet<Product> Products{ get; set; }

    public ProductsContext(DbContextOptions<ProductsContext> contextOptions):base(contextOptions){
        
}
}