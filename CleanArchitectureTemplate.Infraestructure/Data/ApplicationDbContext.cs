using CleanArchitectureTemplate.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Agregamos las entidades o modelos con DbSet de nuestra aplicación aquíÇ
        public DbSet<Producto> Productos { get; set; }

    }
}
