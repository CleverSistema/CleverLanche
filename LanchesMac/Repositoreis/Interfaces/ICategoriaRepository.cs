using LanchesMac.Models;

namespace LanchesMac.Repositoreis.Interfaces
{
    public class ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; set; }
    }
}
