using Microsoft.AspNetCore.Mvc;
using TesteUnitario.ServiceProxy;

namespace TesteUnitarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : Controller
       
    {
        private readonly IProdutoService produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            this.produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var produto = produtoService.ObterProduto();

            return Ok(produto);
        }
    }
}
