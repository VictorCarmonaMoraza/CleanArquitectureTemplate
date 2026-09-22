using CleanArchitectureTemplate.Application.DTOs;
using CleanArchitectureTemplate.Application.UseCases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace CleanArchitectureTemplate.Web.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ProductoService _productoService;

        public ProductosController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public async Task<IActionResult> Index()
        {
            var productos = await _productoService.ObtenerProductosAsync();
            return View(productos);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(ProductoDTO productoDTO)
        {
            // Retornar la vista con el modelo si hay errores de validación
            if (!ModelState.IsValid)
            {
                return View(productoDTO);
            }
            await _productoService.AgregarProductoAsync(productoDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(ProductoDTO productoDTO)
        {
            // Retornar la vista con el modelo si hay errores de validación
            if (!ModelState.IsValid)
            {
                return View(productoDTO);
            }
            await _productoService.ActualizarProductoAsync(productoDTO);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmado(int id)
        {
            var producto = await _productoService.ObtenerProductoPorIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            await _productoService.EliminarProductoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
