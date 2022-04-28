using Moq;
using NUnit.Framework;
using UserTicketService.Contracts;

namespace UserTicketService.Tests
{
    [TestFixture]
    public class TicketPriceTests
    {
        [Test]
        public void TicketPriceMustReturnNotNullableTicket()
        {
            // Arrange
            var mockTicketService = new Mock<ITicketService>();
            mockTicketService.Setup(p => p.GetTicketPrice(1)).Returns(100);
            mockTicketService.Setup(p => p.GetTicketPrice(2)).Returns(500);
            mockTicketService.Setup(p => p.GetTicketPrice(3)).Returns(7800);

            var ticketPriceTest = new TicketPrice(mockTicketService.Object);

            // Act Assert
            Assert.That(ticketPriceTest.MakeTicketPrice(3) == 7800);
        }
    }
}
