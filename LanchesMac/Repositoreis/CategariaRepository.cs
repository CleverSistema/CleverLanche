using LanchesMac.Context;
using LanchesMac.Models;
using LanchesMac.Repositoreis.Interfaces;

namespace LanchesMac.Repositoreis
{
    public class CategariaRepository : ICategoriaRepository
    {
        private readonly AppDbContext _context;

        public CategariaRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Categoria> Categorias => _context.Categorias;
       
    }
}
