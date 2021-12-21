using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TesteUnitario.ServiceProxy;
using TesteUnitarioAPI.Controllers;
using Xunit;

namespace TesteUnitarioXUnit
{
    public class Calculadora
    {
        //Teste com XUnit, estrutura mais evoluida e facil assimilação


        [Fact(DisplayName = "Verificar Soma")]
        public void VerificarSoma()
        {
            //Arrange
            //Setup
            int valor1 = 5;
            int valor2 = 3;

            //Act
            //Exercise
            var controler = new CalculadoraControler();
            var resultado = controler.Somar(valor1, valor2);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            //Assert
            //Verify
            Assert.True(okObjectResult != null);
            Assert.Equal(valor.Value, 8);
        }


        [Theory(DisplayName = "Verificar Subtração")]
        [Trait("Categoria", "Subtração")] //Possibilidade de agrupar e executar os testes
        [InlineData(5, 3, 2)]
        [InlineData(10, 5, 5)]
        [InlineData(1, 1, 0)]
        public void VerificarSubtracao(int first, int second, int expected)
        {
            //Arrange
            //Setup

            //Act
            //Exercise
            var controler = new CalculadoraControler();
            var resultado = controler.Subtrair(first, second);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            //Assert
            //Verify
            Assert.True(okObjectResult != null);
            Assert.Equal(valor.Value, expected);
        }

     

        [Theory(DisplayName = "Verificar Subtração com Lista")]
        [Trait("Categoria", "Subtração")] //Possibilidade de agrupar e executar os testes
        [MemberData(nameof(NumeroLista))] //Possibilidade de testar a partir de um csv ou banco
        public void VerificarSubtracaoComLista(NumerosDto numero)
        {
            //Arrange
            //Setup

            //Act
            //Exercise
            var controler = new CalculadoraControler();
            var resultado = controler.Subtrair(numero.Primeiro, numero.Segundo);

            var okObjectResult = resultado as OkObjectResult;

            var valor = okObjectResult.Value as int?;

            //Assert
            //Verify
            Assert.True(okObjectResult != null);
            Assert.Equal(valor.Value, numero.Esperado);
        }


        public static IEnumerable<object[]> NumeroLista => new[]
        {
            new [] { new NumerosDto { Primeiro = 2, Segundo = 1, Esperado = 1 }},
            new [] { new NumerosDto { Primeiro = 3, Segundo = 1, Esperado = 2 }},
        };


        //[Fact(DisplayName = "Verificar Divisão por zero", Skip = "Não implementado")] //Pode ser utilizado quando não implementado
        [Fact(DisplayName = "Verificar Divisão por zero")]
        public void VerificarDivisaoZero()
        {
            //TODO: Precisa ser implementado

            //Arrange
            //Setup
            int valor1 = 5;
            int valor2 = 0;

            var ex = Record.Exception(() => ThrowAnException());

            if (!(ex is DivideByZeroException))
                Assert.True(false);
        }

        private void ThrowAnException()
        {
            throw new DivideByZeroException();
        }

    }
}