using Microsoft.EntityFrameworkCore;
using web_1.Models;

namespace web_1.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options){ 
        }
        public DbSet<Kullanici> kullanici { get; set; }
    }
}
