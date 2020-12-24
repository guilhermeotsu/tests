using Xunit;

namespace Demo.Tests
{
    public class CalculadoraTests
    {
        [Fact]
        public void Calculadora_Somar_DeveRetornarValorSomado()
        {
            // arrange
            double valor1 = 10;
            double valor2 = 15;

            // act
            var actual = new Calculadora().Somar(valor1, valor2);

            // assert
            Assert.Equal(25, actual);
        }
    }
}
