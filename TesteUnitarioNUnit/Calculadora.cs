using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using TesteUnitarioAPI.Controllers;

namespace Tests
{

    public class TesteUnitarioNUnit
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
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

        [Test]
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