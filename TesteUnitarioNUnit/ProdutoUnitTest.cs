using Microsoft.AspNetCore.Mvc;
using TesteUnitario.ServiceProxy;
using TesteUnitarioAPI.Controllers;
using NUnit.Framework;
using Moq;

namespace TesteUnitarioNUnit
{

    public class Produto
    {
        //Criando um Mock da IOC do Produto Service, neste caso não vamos testar o serviço, apenas o código que a utiliza.
        private Mock<IProdutoService> mockProdutoService { get; set; }

        [SetUp]
        public void Init()
        {
        }


        [Test]
        public void TestarObterProduto()
        {
            //Instanciando a IOC com o Mock
            mockProdutoService = new Mock<IProdutoService>();

            //Setup para o retorno do Mock quando utilizado e chamado
            mockProdutoService.Setup(p => p.ObterProduto()).Returns(ResponseObterProdutoMock);

            //Exemplo e teste usando controller, quando retorno IActionResult
            var controler = new ProdutoController(mockProdutoService.Object);
            var resultado = controler.Get();

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as ProdutoDto;

            NUnit.Framework.Assert.IsNotNull(okObjectResult);
            NUnit.Framework.Assert.AreEqual(valor.Codigo, 9999);
            NUnit.Framework.Assert.AreEqual(valor.Descricao, "TesteMock");
        }

        //Classe Mock para testes
        public ProdutoDto ResponseObterProdutoMock()
        {
            var produto = new ProdutoDto();
            produto.Descricao = "TesteMock";
            produto.Codigo = 9999;
            return produto;
        }

    }



}