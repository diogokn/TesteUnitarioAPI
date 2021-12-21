using Microsoft.AspNetCore.Mvc;

namespace TesteUnitarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculadoraControler : Controller
    {
        [HttpGet]

        public IActionResult Get()
        {
            var resultado = 100;

            return Ok(resultado);
        }

        [HttpGet("Somar")]
        public IActionResult Somar(int valor1, int valor2)
        {
            var resultado = valor1 + valor2;

            return Ok(resultado);
        }

        [HttpGet("Subtrair")]
        public IActionResult Subtrair(int valor1, int valor2)
        {
            var resultado = valor1 - valor2;

            return Ok(resultado);
        }

        [HttpGet("Dividir")]
        public IActionResult Dividir(int valor1, int valor2)
        {
            var resultado = valor1 / valor2;

            return Ok(resultado);
        }
    }
}
