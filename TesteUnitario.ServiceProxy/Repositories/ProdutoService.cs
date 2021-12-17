
namespace TesteUnitario.ServiceProxy
{
    public class ProdutoService: IProdutoService
    {
        public ProdutoDto ObterProduto()
        {
            var produto = new ProdutoDto();
            produto.Descricao = "Teste";
            produto.Codigo = 1;
            return produto;
        }

    }
}
