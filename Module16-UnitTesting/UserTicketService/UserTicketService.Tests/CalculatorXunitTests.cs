using Practices;
using System;
using Xunit;

namespace UserTicketService.Tests
{
    public class CalculatorXunitTests
    {
        [Fact]
        public void Addition_MustReturnCorrectValue()
        {
            // Arrange
            var calculator = new Calculator();

            //Assert
            Assert.Equal(10, calculator.Addition(5, 5));
        }

        [Fact]
        public void Subtraction_MustReturnCorrectValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.True(calculator.Subtraction(300, 10) == 290);
        }

        [Fact]
        public void Multiplication_MustReturnNotNullValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Act Assert
            Assert.Equal(8, calculator.Multiplication(2, 4));
        }
       

        [Fact]
        public void Division_MustReturnCorrectValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.True(calculator.Division(200, 10) == 20);
        }

        [Fact]
        public void Division_MustThrowException()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Division(30, 0));
        }
    }
}
