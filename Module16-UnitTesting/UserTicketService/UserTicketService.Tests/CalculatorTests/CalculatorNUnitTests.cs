using NUnit.Framework;
using Practices;
using System;

namespace UserTicketService.Tests.CalculatorTests
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void Addition_MustReturnCorrectValue()
        {
            // Arrange
            var calculatorTest = new Calculator();

            // Assert
            Assert.That(calculatorTest.Addition(10, 220), Is.EqualTo(230));
        }

        [Test]
        public void Subtraction_MustReturnCorrectValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.That(calculator.Subtraction(300, 10) == 290);
        }

        [Test]
        public void Multiplication_MustReturnNotNullValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            var result = calculator.Multiplication(2, 4);

            // Assert
            Assert.AreEqual(8, result);
        }              

        [Test]
        public void Division_MustReturnCorrectValue()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.That(calculator.Division(9, 3) == 3);
        }

        [Test]
        public void Division_MustThrowException()
        {
            // Arrange
            var calculator = new Calculator();

            // Assert
            Assert.Throws<DivideByZeroException>(() => calculator.Division(30, 0));
        }

        
    }
}
