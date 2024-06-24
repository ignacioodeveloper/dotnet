using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBeerController : ControllerBase
    {

        // creamos una var privada que almcena el contexto
        private readonly Pub1Context _context;

        // otra funcion que guarda en la api el contexto
        public ApiBeerController(Pub1Context context)
        {
            _context = context;
        }

        // funcional porque trae una list asincronica de los datos para
        // usarlos en el front end
        public async Task<List<BeerBrandViewModel>> Get()
            => await _context.Beers.Include(b => b.Brand)
            .Select(b=>new BeerBrandViewModel
            {
                Name = b.Name,
                Brand = b.Brand.Name
            })
            .ToListAsync();

    }
}
