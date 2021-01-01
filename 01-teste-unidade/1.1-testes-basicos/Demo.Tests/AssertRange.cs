using System;
using Xunit;

namespace Demo.Tests
{
    public class AssertRange
    {
        [Theory]
        [InlineData(700)]
        [InlineData(1999)]
        [InlineData(2000)]
        [InlineData(7999)]
        [InlineData(8000)]
        [InlineData(10000)]
        public void Funcionario_Salario_FaixasSalariaisDeveRespeitarSenioridade(decimal salario)
        {
            // Arrange e Act
            var funcionario = new Funcionario("Guilherme", salario);

            // Assert
            if (funcionario.Senioridade == NivelProfissional.Junior)
                Assert.InRange(funcionario.Salario, 500, 1999);

            if (funcionario.Senioridade == NivelProfissional.Pleno)
                Assert.InRange(funcionario.Salario, 2000, 7999);

            if (funcionario.Senioridade == NivelProfissional.Senior)
                Assert.InRange(funcionario.Salario, 8000, decimal.MaxValue);

            Assert.NotInRange(funcionario.Salario, 0, 499);
        }
    }
}
