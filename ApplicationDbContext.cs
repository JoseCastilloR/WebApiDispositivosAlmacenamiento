using Microsoft.EntityFrameworkCore;
using WebApiDispositivosAlmacenamiento.Entidades;

namespace WebApiDispositivosAlmacenamiento
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<DispositivoAlmacenamiento> DispositivosAlmacenamiento { get; set; }
    }
}
