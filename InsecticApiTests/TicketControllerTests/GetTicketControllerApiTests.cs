using System;
using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using InsecticDatabaseApi.Controllers;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InsecticApiTests.TicketControllerTests
{
    
    public class GetTicketControllerApiTests
    {
        private readonly Mock<ITicketData> repoStub = new Mock<ITicketData>(MockBehavior.Strict);
        
        [Fact] // Good Test
        public void GetAllTickets_ReturnsAllTickets_ListOfTicketsOkObjectResult()
        {
            var tList = new List<Ticket>
            {
                new Ticket(){ TicketId = 123}, new Ticket(){TicketId = 234}
            };

           //Arrange
           repoStub.Setup(repo => repo.GetAllTickets()).Returns(tList);

            //Act
            var controller = new TicketController(repoStub.Object);
            var result = controller.GetAllTickets();
           //Assert
           repoStub.VerifyAll();
           var returnList = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tList,returnList.Value);
        }

       
        [Fact]
        public void GetTicket_WithExistingTicketId_OkObjectResult()
        {
            var tic = new Ticket()
            {
                TicketId = 123, TicketDescription = "test", UserId = "testUId", AssignedUser = "ddubose", Category = "testBug",
                IncidentDate = new DateTime(2021,11,04), Priority = "urgent", Status = "in Progress", Comments = null, DueDate = null
            };
            //Arrange
            repoStub.Setup(repo => repo.GetTicket(123)).Returns(tic);
            //Act
            var controller = new TicketController(repoStub.Object);
            var sut =  controller.GetTicket(123);
            //Assert
            repoStub.VerifyAll();
            var returnTicket = Assert.IsType<OkObjectResult>(sut);
            Assert.IsType<OkObjectResult>(sut);
            Assert.Equal(tic, returnTicket.Value);
        }

        [Fact]
        public void GetTicket_WithNonExistingTicketId_NotFoundObjectResult()
        {
            //Arrange
            repoStub.Setup(repo => repo.GetTicket(123)).Returns(null as Ticket);
            //Act
            var controller = new TicketController(repoStub.Object);
            var sut = controller.GetTicket(123);
            //Assert
            repoStub.VerifyAll();
           var returnString = Assert.IsType<NotFoundObjectResult>(sut);
           Assert.IsType<NotFoundObjectResult>(sut);
           Assert.Equal("Ticket with Id of 123 does not exist", returnString.Value);
        }

        [Fact]
        public void GetTicketByUserId_WithNonExistingUser_ReturnsNotFoundResults()
        {
            //Arrange
            var userId = "test";
            repoStub.Setup(repo => repo.GetUserTickets(userId))
                    .Returns((List<Ticket>)null);
            var sut = new TicketController(repoStub.Object);
            //Act
            var result = sut.GetTicketByUserId(userId);
            //Assert
            repoStub.VerifyAll();
            var returnValue = Assert.IsType<NotFoundObjectResult>(result);
            Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal($"Tickets associated with the User Id of {userId} do not exist",returnValue.Value);
        }

        public class ExistingUserIdData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { "testId", new List<Ticket>() };
                yield return new object[] { "userId", new List<Ticket>() { new Ticket() } };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        [Theory]
        [ClassData(typeof(ExistingUserIdData))]
        public void GetTicketByUserId_WithExistingUser_ListOfTicketsOkObjectResult(string userId, List<Ticket> tickets)
        {

            //Arrange
            repoStub.Setup(repo => repo.GetUserTickets(userId))
                .Returns(tickets);

            //creates a controller object and passes in our mock dependency 
            var sut = new TicketController(repoStub.Object);

            //Act
            var result = sut.GetTicketByUserId(userId);
            //Assert
            repoStub.VerifyAll();
            var returnValue = Assert.IsType<OkObjectResult>(result);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(tickets,returnValue.Value);
        }

        //error with controller reading ticket
        //[Fact]
        //public void AddTicket_ValidTicket_CreatedStatusCode()
        //{
        //    //Arrange
        //    var tic = new Ticket()
        //    {
        //        TicketId = 123,
        //        TicketDescription = "test",
        //        UserId = "testUId",
        //        AssignedUser = "ddubose",
        //        Category = "testBug",
        //        IncidentDate = new DateTime(2021, 11, 04),
        //        Priority = "urgent",
        //        Status = "in Progress",
        //        Comments = null,
        //        DueDate = null
        //    };
        //    var sut = new TicketController(repoStub.Object);
        //    repoStub.Setup(repo => repo.AddTicket(tic));
        //    //Act
        //    var result = sut.AddTicket(tic);
        //    //Assert
        //    repoStub.VerifyAll();
            
        //}



    }
}
