using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using FakeItEasy.Core;
using FluentAssertions;
using InsecticDatabaseApi.Controllers;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace InsecticApiTests.Tickets
{
    public class GetTicketControllerApiTests
    {
        //this is a stub that makes an instance of dependency that does not need to be tested
        private readonly Mock<ITicketData> repoStub = new Mock<ITicketData>();

        Random random = new Random();

        [Fact]
        public void GetAllTickets_RETURNS_ALL_TICKETS_ASSIGNED_TO_USER()
        {

            //Arrange
            int count = 40;
            var fakeTickets = A.CollectionOfDummy<Ticket>(count).AsEnumerable();
            var fakeDependency = A.Fake<ITicketData>();
            var testController = new TicketController(fakeDependency);
            A.CallTo(() => fakeDependency.GetAllTickets()).Returns(fakeTickets.ToList());
            //Act
            var actionResult = testController.GetAllTickets();
            //Assert
            var result = actionResult as OkObjectResult;
            var returnList = result.Value as List<Ticket>;
            Assert.Equal(count, returnList.Count());
        }

        [Fact]
        public void GetTicket_RETURNS_SINGLE_TICKET_BASED_ON_TICKET_ID()
        {
            //Arrange
            var hardCodeDate = new DateTime(year: 2021, month: 04, day: 11, hour: 04, minute: 04, second: 04);
            var searchId = 102;
            var fakeTickets = new List<Ticket>
            {
                new Ticket
                {
                    Category = "urgent", IncidentDate = hardCodeDate, Priority = "urgent", Status = "pending",
                    TicketDescription = "test", TicketId = 100, UserId = "ddub"
                },
                new Ticket
                {
                    Category = "urgent", IncidentDate = hardCodeDate, Priority = "urgent", Status = "pending",
                    TicketDescription = "test", TicketId = 101, UserId = "ddub"
                },
                new Ticket
                {
                    Category = "urgent", IncidentDate = hardCodeDate, Priority = "urgent", Status = "pending",
                    TicketDescription = "test", TicketId = 102, UserId = "ddub"
                },
                new Ticket
                {
                    Category = "urgent", IncidentDate = hardCodeDate, Priority = "urgent", Status = "pending",
                    TicketDescription = "test", TicketId = 103, UserId = "ddub"
                }
            };
            var fakeDependency = A.Fake<ITicketData>(); // Fake Interface/dependency
            var testController = new TicketController(fakeDependency);
            A.CallTo(() => fakeDependency.GetTicket(searchId)).Returns(fakeTickets.Find(p => p.TicketId == searchId));

            //Act
            var actionResult = testController.GetTicket(searchId);

            //Assert
            var result = actionResult as OkObjectResult;
            var returnTicket = result.Value as Ticket;
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(fakeTickets[2], returnTicket);
        }

        [Fact]
        public void GetTicketByUser_SHOULD_RETURN_ONLY_TICKET_ASSIGNED_TO_USER()
        {
            //Arrange
            var userSearch = "test";
            var fakeTickets = new List<Ticket>
            {
                new Ticket
                {
                    Category = "urgent", Comments = null, DueDate = null, IncidentDate = DateTime.MinValue,
                    Priority = "urgent", Status = "pending", TicketDescription = "test", TicketId = 100,
                    UserId = "rand1"
                },
                new Ticket
                {
                    Category = "urgent", Comments = null, DueDate = null, IncidentDate = DateTime.MinValue,
                    Priority = "urgent", Status = "pending", TicketDescription = "test", TicketId = 101, UserId = "test"
                },
                new Ticket
                {
                    Category = "urgent", Comments = null, DueDate = null, IncidentDate = DateTime.MinValue,
                    Priority = "urgent", Status = "pending", TicketDescription = "test", TicketId = 102, UserId = "test"
                },
                new Ticket
                {
                    Category = "urgent", Comments = null, DueDate = null, IncidentDate = DateTime.MinValue,
                    Priority = "urgent", Status = "pending", TicketDescription = "test", TicketId = 103, UserId = "rand"
                }
            };

            var fakeDependency = A.Fake<ITicketData>();
            var testController = new TicketController(fakeDependency);

            A.CallTo(() => fakeDependency.GetUserTickets(userSearch))
                .ReturnsLazily(fakeTickets.Where(t => t.UserId.Equals(userSearch)).ToList);

            //Act
            var actionResult = testController.GetTicketByUser(userSearch);
            //Assert
            var result = actionResult as OkObjectResult;
            var returnTicketList = result.Value as List<Ticket>;
            Assert.Equal(new List<Ticket> {fakeTickets[1], fakeTickets[2]}, returnTicketList);
        }

        [Fact]
        public void GetTicketByUser_WithNonExistingUser_ReturnsNotFound()
        {
            //Arrange
            //since I want this to fail, the It.isAny<string> tells moq to put any value in there. 
            //This is saying with this inserted, the return should be a null list. 

            repoStub.Setup(repo => repo.GetUserTickets(It.IsAny<string>()))
                .Returns((List<Ticket>) null);

            //creates a controller object and passes in our mock dependency 
            var controller = new TicketController(repoStub.Object);

            //Act
            var result = controller.GetTicketByUser(It.IsAny<string>());
            //Assert

            Assert.IsType<NotFoundObjectResult>(result);
        }
        [Fact]
        public void GetTicketByUser_WithExistingUser_ListOfTickets()
        {
            //Arrange 
            var expectedTicket = new List<Ticket>{ CreateRandomTicket(),CreateRandomTicket()};
            repoStub.Setup(repo => repo.GetUserTickets(It.IsAny<string>()))
                .Returns(expectedTicket);
            var controller = new TicketController(repoStub.Object);
            //Act
            var result = controller.GetTicketByUser(It.IsAny<string>());
            //Assert

            Assert.IsType<OkObjectResult>(result);
            
        }

        private Ticket CreateRandomTicket()
        {
            return new Ticket()
            {
                TicketId = 100, UserId = Guid.NewGuid().ToString(), IncidentDate = DateTime.Now,
                TicketDescription = random.Next(30000).ToString(),
                Category = random.Next(0, 5).ToString(), DueDate = null, Priority = random.Next(0,5).ToString(), Status = random.Next(0,5).ToString()

            };
        }



    }
}
