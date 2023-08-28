using CRUDtest.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDtest.Data;

public class CarDbContext  : DbContext
{

    public CarDbContext()
    {
        
    }
    
    public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
    {
        
    }
    public DbSet<Car> Cars { get; set; }
    
}