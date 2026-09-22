using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;
using CleanArchitectureTemplate.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureTemplate.Infraestructure.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task AgregarAsync(Producto producto)
        {
            await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con Id {id} no encontrado.");
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

        public async Task<Producto> ObtenerPorIdAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con Id {id} no encontrado.");
            }
            return producto;
        }

        public Task<Producto> ObtenerPorNombreAsync(string nombre)
        {
           var producto = _context.Productos.FirstOrDefaultAsync(p => p.Nombre == nombre);
            if (producto == null)
            {
                throw new KeyNotFoundException($"Producto con Nombre {nombre} no encontrado.");
            }
            return producto;
        }

        public Task<IEnumerable<Producto>> ObtenerTodosAsync()
        {
            var productos = _context.Productos.ToListAsync();
            if (productos == null || productos.Result.Count == 0)
            {
                throw new KeyNotFoundException("No se encontraron productos.");
            }
            return productos.ContinueWith(t => (IEnumerable<Producto>)t.Result);
        }
    }
}
