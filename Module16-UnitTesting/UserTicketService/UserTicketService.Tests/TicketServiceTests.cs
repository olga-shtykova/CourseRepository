using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            NUnit.Framework.Assert.IsNotNull(ticketServiceTest.GetTicketPrice(1));
        }

        [Test]
        public void GeTicketPriceMustThrowException()
        {
            // Arrange
            var ticketServiceTest = new TicketService();

            // Assert
            NUnit.Framework.Assert.Throws<TicketNotFoundException>(() => ticketServiceTest.GetTicketPrice(100));
        }

        [Test]
        public void SaveTicket()
        {
            // Arrange
            var ticketServiceTest = new TicketService();
            var newTicket = new Ticket(4, "Test ticket", 1000);

            // Act
            ticketServiceTest.SaveTicket(newTicket);
            var allTicketsAfterAddingNewTicket = ticketServiceTest.GetAllTickets();

            // Assert
            NUnit.Framework.CollectionAssert.Contains(allTicketsAfterAddingNewTicket, newTicket);

            PrivateObject obj = new PrivateObject(ticketServiceTest);

            obj.Invoke("DeleteTicket", newTicket);

            // Act
            var allTicketsAfterDeletingNewTicket = ticketServiceTest.GetAllTickets();

            // Assert
            NUnit.Framework.CollectionAssert.DoesNotContain(allTicketsAfterDeletingNewTicket, newTicket);
        }

    }   
}
