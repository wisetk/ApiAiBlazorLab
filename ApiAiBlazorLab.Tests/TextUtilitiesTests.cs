using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAiBlazorLab.Tests
{
    public class TextUtilitiesTests
    {
        [Fact]
        public void NullInput()
        {
            // Arrange
            string input = null;

            // Act
            string output = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.True(output == "No fact available.");
        }

        [Fact]
        public void EmptyString()
        {
            // Arrange
            string input = " ";

            // Act
            string output = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.True(output == "No fact available.");
        }

        [Fact]
        public void MissingPeriod()
        {
            // Arrange
            string input = "Hello world";

            // Act 
            string output = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.False(input == output);
        }

        [Fact]
        public void ExistingPeriod()
        {
            // Arrange
            string input = "Good morning Night City.";

            // Act
            string output = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.True(input == output);
        }

        [Fact]
        public void ExtraWhitespace()
        {
            // Arrange
            string input = "   leading whitespace.";

            // Act
            string output = TextUtilities.NormalizeFact(input);

            // Assert
            Assert.False(input == output);
        }
    }
}
