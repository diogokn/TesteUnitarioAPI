using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteUnitarioAPI.Controllers;

namespace TesteUnitarioMSTest
{
    [TestClass]
    public class TesteUnitarioNUnit
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestMethod]
        public void TestarCalculadoraSoma()
        {
            int valor1 = 5;
            int valor2 = 3;

            var controler = new CalculadoraControler();
            var resultado = controler.Somar(valor1, valor2);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            Assert.IsNotNull(okObjectResult);
            Assert.AreEqual(valor.GetValueOrDefault(), 8);
        }

        [TestMethod]
        public void TestarCalculadoraSubtrair()
        {
            int valor1 = 5;
            int valor2 = 3;

            var controler = new CalculadoraControler();
            var resultado = controler.Subtrair(valor1, valor2);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            Assert.IsNotNull(okObjectResult);
            Assert.AreEqual(valor.GetValueOrDefault(), 2);
        }
    }
}