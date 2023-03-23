using LanchesMac.Repositoreis.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _LancheRepository;

        public LancheController(ILancheRepository lancheRepository)
        {
            _LancheRepository = lancheRepository;
        }

        public IActionResult List()
        {
            var lanches = _LancheRepository.Lanches;
            return View(lanches);
        }
    }
}
