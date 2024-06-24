using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{

	public class BeerController : Controller
	{

		// contexto db
		private readonly Pub1Context _context;

		public BeerController(Pub1Context context)
		{
			_context = context;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

		public async Task<IActionResult> Index()
		{
			// importante el Include para traer los datos
			var beers = _context.Beers.Include(b => b.Brand);
			return View(await beers.ToListAsync());
		}

		// metodo c.r.u.d

		// combobox para tener las marcas en context
		public IActionResult Create()
		{
			// diccionario para acceder desde la vista
			// en el form va el primery key y en la vista va el nombre
			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name");
			return View();
		}

		// token valida la info del FORMULARIO
		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BeerViewModel model)
        {

			if(ModelState.IsValid)
			{
				var beer = new Beer()
				{
					Name = model.Name,
					BrandId = model.BrandId
				};

				// agregamos beer
				_context.Add(beer);

				// otras cosas para hacer

				// aca se manda a la bd
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}

			ViewData["Brands"] = new SelectList(_context.Brands, "BrandId", "Name", model.BrandId);

            return View(model);
        }

    }
}
