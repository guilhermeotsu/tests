using System;
using Xunit;

namespace Demo.Tests
{
    public class StringToolsTests
    {
        [Fact]
        public void StringTools_UnirNomes_DeveRetonarTrue()
        {
            // Arrange/Act
            var result = "Guilherme".Juntar("Otsu");

            // Assert
            Assert.Equal("Guilherme Otsu", result, true);
        }

        [Fact]
        public void StringTools_Contains_DeveRetornarTrue()
        {
            // Arrange/Act
            var result = "Guilherme".Juntar("Otsu");

            // Assert
            Assert.Contains("erme", result);
        }

        [Fact]
        public void StringTools_EndsWith_DeveRetornarTrue()
        {
            // Arrange/Act
            var result = "Guilherme".Juntar("Otsu");

            // Assert
            Assert.EndsWith("tsu", result);
        }

        [Fact]
        public void StringTools_StartWith_DeveRetornarTrue()
        {
            // Arrange/Act
            var result = "Stringona".Juntar("Gigante");

            // Assert
            Assert.StartsWith("Strin", result, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void StringTools_DoesNotContain_DeveRetornarTrue()
        {
            // Arrange/Act
            var result = "Stringona".Juntar("Gigante");

            // Assert
            Assert.DoesNotContain("123", result);
        }
    }
}
