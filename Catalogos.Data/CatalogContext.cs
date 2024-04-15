using System.Security.Claims;
using System.Threading.Tasks;
using Catalogos.Entities.Model;
using Microsoft.EntityFrameworkCore;

namespace Catalogos.Data
{
    public class CatalogContext : DbContext
    {

        public DbSet<task> Tasks { get; set; }
        public DbSet<user> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

    }
}