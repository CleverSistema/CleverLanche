using LanchesMac.Context;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {

        private readonly AppDbContext _appDbContext;

        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CarrinhoCompraId { get; set; }

        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }

        public static CarrinhoCompra GetCarrinho(IServiceProvider service) 
        { 

            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };

        }
        public void AdicionarAoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                    s => s.Lanche.LancheId == lanche.LancheId &&
                    s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _appDbContext.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
            _appDbContext.SaveChanges();
            
        }

        public int RemoverDoCarrinho(Lanche lanche)
        {
            var carrinhoCompraItem = _appDbContext.CarrinhoCompraItens.SingleOrDefault(
                   s => s.Lanche.LancheId == lanche.LancheId &&
                   s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                        _appDbContext.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            _appDbContext.SaveChanges();
            return quantidadeLocal;
        }
    }
}
