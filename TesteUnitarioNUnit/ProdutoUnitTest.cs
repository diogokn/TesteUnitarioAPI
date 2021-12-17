using Microsoft.AspNetCore.Mvc;
using TesteUnitario.ServiceProxy;
using TesteUnitarioAPI.Controllers;
using NUnit.Framework;
using Moq;

namespace TesteUnitarioNUnit
{

    public class Produto
    {
        private Mock<IProdutoService> mockProdutoService { get; set; }

        [SetUp]
        public void Init()
        {
            mockProdutoService = new Mock<IProdutoService>();
            mockProdutoService.Setup(p => p.ObterProduto()).Returns(ResponseObterProdutoMock);
        }


        [Test]
        public void TestarObterProduto()
        {
            mockProdutoService = new Mock<IProdutoService>();
            mockProdutoService.Setup(p => p.ObterProduto()).Returns(ResponseObterProdutoMock);
            var controler = new ProdutoController(mockProdutoService.Object);
            var resultado = controler.Get();

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as ProdutoDto;

            NUnit.Framework.Assert.IsNotNull(okObjectResult);
            NUnit.Framework.Assert.AreEqual(valor.Codigo, 9999);
            NUnit.Framework.Assert.AreEqual(valor.Descricao, "TesteMock");
        }

        public ProdutoDto ResponseObterProdutoMock()
        {
            var produto = new ProdutoDto();
            produto.Descricao = "TesteMock";
            produto.Codigo = 9999;
            return produto;
        }

    }



}