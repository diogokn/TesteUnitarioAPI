using Microsoft.AspNetCore.Mvc;
using TesteUnitarioAPI.Controllers;
using Xunit;

namespace TesteUnitarioXUnit
{
    public class Calculadora
    {
        
        //Teste com XUnit, estrutura mais evoluida e facil assimilação

        [Fact]
        public void TestarSoma()
        {
            int valor1 = 5;
            int valor2 = 3;

            var controler = new CalculadoraControler();
            var resultado = controler.Somar(valor1, valor2);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            Assert.True(okObjectResult != null);
            Assert.Equal(valor.GetValueOrDefault(), 8);
        }
    }
}