using Xunit;

namespace Demo.Tests
{
    public class AssertNullBoolTests
    {
        [Fact]
        public void Funcionario_Nome_NuncaDeveVazio()
        {
            // Arrange e Act
            var funcionario = new Funcionario("", 5000);

            // Assert
            Assert.NotNull(funcionario.Nome);
            Assert.False(string.IsNullOrEmpty(funcionario.Nome));
            Assert.True(funcionario.Nome.Length > 0);
        }

        [Fact]
        public void Funcionario_Apelido_DeveSerNulo()
        {
            // Arrange e Act
            var funcionario = new Funcionario("", 10000);

            // Assert
            Assert.Null(funcionario.Apelido);
            Assert.True(string.IsNullOrEmpty(funcionario.Apelido));
            Assert.False(funcionario.Apelido?.Length > 0);
        }
    }
}
