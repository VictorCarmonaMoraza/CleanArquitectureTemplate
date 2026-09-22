using System.ComponentModel.DataAnnotations;

namespace CleanArchitectureTemplate.Application.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre del producto no puede exceder los 100 caracteres")]
        public string Nombre { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio del producto debe ser mayor que cero")]
        public decimal Precio { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
