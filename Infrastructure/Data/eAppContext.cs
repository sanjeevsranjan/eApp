
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class eAppContext: DbContext
    {
    public eAppContext(DbContextOptions<eAppContext> options) : base(options)
        {
        }
    public DbSet<Product> Products { get; set; }
    }
}