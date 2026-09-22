using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.Interfaces;

namespace CleanArchitectureTemplate.Application.UseCases
{
    public class ProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos y los mapea a DTOs.
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProductoDTO>> ObtenerProductosAsync()
        {
            var productos = await _productoRepository.ObtenerTodosAsync();
            // Mapear los productos a DTOs
            return productos.Select(p => new ProductoDTO
            {
                Id = p.Id,
                Nombre = p.Nombre,
                Precio = p.Precio,
                Descripcion = p.Descripcion,
                FechaCreacion = p.FechaCreacion
            }).ToList();
        }

        /// <summary>
        /// Obtiene un producto por su ID y lo mapea a un DTO.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductoDTO> ObtenerProductoPorIdAsync(int id)
        {
            var producto = await _productoRepository.ObtenerPorIdAsync(id);
            if (producto == null)
            {
                return null;
            }
            return new ProductoDTO
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Precio = producto.Precio,
                Descripcion = producto.Descripcion,
                FechaCreacion = producto.FechaCreacion
            };
        }

        /// <summary>
        /// Agrega un nuevo producto a la base de datos.
        /// </summary>
        /// <param name="productoDTO"></param>
        /// <returns></returns>
        public async  Task AgregarProductoAsync(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Descripcion = productoDTO.Descripcion,
                FechaCreacion = DateTime.Now
            };
            await _productoRepository.AgregarAsync(producto);
        }

        public async Task ActualizarProductoAsync(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                Id = productoDTO.Id,
                Nombre = productoDTO.Nombre,
                Precio = productoDTO.Precio,
                Descripcion = productoDTO.Descripcion,
                FechaCreacion = productoDTO.FechaCreacion
            };
            await _productoRepository.ActualizarAsync(producto);
        }

        public async Task EliminarProductoAsync(int id)
        {
            if(id<= 0)
            {
                throw new ArgumentException("El ID del producto debe ser mayor que cero.", nameof(id));
            }
            await _productoRepository.EliminarAsync(id);
        }
}
