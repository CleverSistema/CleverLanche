using LanchesMac.Models;

namespace LanchesMac.Repositoreis.Interfaces
{
    public interface ILancheRepository
    {

        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchesPreferidos { get; }

        Lanche GetLancheById(int lancheId);
    }
}
