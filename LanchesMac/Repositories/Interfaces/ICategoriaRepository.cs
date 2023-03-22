using LanchesMac.Models;

namespace LanchesMac.Repositoreis.Interfaces
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get;}
    }
}
