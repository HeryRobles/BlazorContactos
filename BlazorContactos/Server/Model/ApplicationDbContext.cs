using BlazorContactos.Server.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorContactos.Server.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }
        public DbSet<Contacto> Contactos { get; set; }

        public DbSet<MediosContacto> MediosContactos { get; set; }

    }
}
