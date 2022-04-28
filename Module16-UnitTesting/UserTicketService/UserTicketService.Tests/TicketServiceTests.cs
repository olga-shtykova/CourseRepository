using NUnit.Framework;
using UserTicketService.Exceptions;

namespace UserTicketService.Tests
{
    [TestFixture]
    public class TicketServiceTests
    {
        [Test]
        public void GeTicketPriceMustReturnNotNullableTicket()
        {
            // Arrange 
            var ticketServiceTest = new TicketService();

            // Assert
            Assert.IsNotNull(ticketServiceTest.GetTicketPrice(1));
        }

        [Test]
        public void GeTicketPriceMustThrowException()
        {
            // Arrange
            var ticketServiceTest = new TicketService();

            // Assert
            Assert.Throws<TicketNotFoundException>(() => ticketServiceTest.GetTicketPrice(100));
        }

    }
}
