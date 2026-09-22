using CleanArchitectureTemplate.Domain.Entities;

namespace CleanArchitectureTemplate.Domain.Interfaces
{
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto> ObtenerPorIdAsync(int id);
        Task<Producto> ObtenerPorNombreAsync(string nombre);
        Task AgregarAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
