using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BrandController : Controller
    {
        // inyecion de dependencias
        // si algo es privado _con _
        private readonly Pub1Context _context;

        public BrandController(Pub1Context context)
        {
            _context = context;
        }
        // async se va ejecutar independientemente mejora el rendimiento
        public async Task<IActionResult> Index()
        {
            // una vista es un archivo razor con esteroides
            // c# en html c# se ejecuta en el servidor
            return View(await _context.Brands.ToListAsync());
        }
    }
}
