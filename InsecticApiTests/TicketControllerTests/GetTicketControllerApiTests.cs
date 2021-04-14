using System;
using System.Collections;
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
    public class ExistingUserIdData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]{"testId",new List<Ticket>()};
            yield return new object[] { "userId", new List<Ticket>(){ new Ticket()}};
            
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class NotFoundUserIdData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "testId" };
            yield return new object[] { "userId" };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



    
    public class GetTicketControllerApiTests
    {
        private readonly Mock<ITicketData> repoStub = new Mock<ITicketData>(MockBehavior.Strict);
        
        Random random = new Random();

        [Fact] // Good Test
        public void GetAllTickets_ReturnsAllTickets_ListOfTickets()
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
        public void GetTicket_ReturnsTicketWithSameTicketId_Ticket()
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
            var fakeDependency = A.Fake<ITicketData>();
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
            
            //Act

            //Assert
        }



        
        //param tests allow for multi tests with edge cases.
       //[Theory]
       //[ClassData(typeof(NotFoundUserIdData))]
       // public void GetTicketByUser_WithNonExistingUser_ReturnsNotFound(string userId)
       // {
        
       // //Arrange
       // //since I want this to fail, the It.isAny<string> tells moq to put any value in there. 
       // //This is saying with this inserted, the return should be a null list. 

       // repoStub.Setup(repo => repo.GetUserTickets(userId))
       //         .Returns((List<Ticket>)null);

       //     //creates a controller object and passes in our mock dependency 
       //     var sut = new TicketController(repoStub.Object);

       //     //Act
       //     var result = sut.GetTicketByUser(userId);
       //     //Assert
       //     repoStub.VerifyAll();

       //     Assert.IsType<NotFoundObjectResult>(result);
        //}
        //[Theory]
        //[ClassData(typeof(ExistingUserIdData))]
        //public void GetTicketByUser_WithExistingUser_ListOfTickets(string userId, List<Ticket>tickets)
        //{

        //    //Arrange
        //    //since I want this to fail, the It.isAny<string> tells moq to put any value in there. 
        //    //This is saying with this inserted, the return should be a null list. 

        //    repoStub.Setup(repo => repo.GetUserTickets(userId))
        //        .Returns(tickets);

        //    //creates a controller object and passes in our mock dependency 
        //    var sut = new TicketController(repoStub.Object);

        //    //Act
        //    var result = sut.GetTicketByUser(userId);
        //    //Assert
        //    repoStub.VerifyAll();

        //    Assert.IsType<OkObjectResult>(result);
        //}

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
