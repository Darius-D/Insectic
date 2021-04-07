using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using InsecticDatabaseApi.InsecticData;
using InsecticDatabaseApi.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Xunit;

namespace InsecticApiTests
{
    public class TicketControllerTests : IClassFixture<WebApplicationFactory<InsecticDatabaseApi.Startup>>
    {
        private Ticket tick = new Ticket();
        public HttpClient _client { get; }

        public TicketControllerTests(WebApplicationFactory<InsecticDatabaseApi.Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task Post_Should_Create_Ticket()
        {
          var values =JsonConvert.SerializeObject( new Ticket()
            {
                Category = "Bug", Priority = "3", Status = "pending", Email = "ddubose@gmail.com",
                PhoneNumber = "860-578-6672", UserId = "123456",
                DueDate = null, IncidentDate = DateTime.Today, TicketDescription = "test description"
            });

           var httpContent = new StringContent(values,Encoding.UTF8,"application/json");
           var httpResponse = await _client.PostAsync("/api/Ticket/", httpContent);
           
           if (httpResponse.Content != null)
           {
               var responseContent = await httpResponse.Content.ReadAsStringAsync();
               
           }

           httpResponse.StatusCode.Should().Be(HttpStatusCode.OK);
           


        }

        //This test checks to make sure a OK status code it returned from the API as well as checks to make sure all ticket 
        // objects in the Database return. The number is 3, however I need to find a way to not hard code this. 
        //Not sure if the Not contain nulls is the best way to ensure it returns all the tickets. I could place a hard coded 
        //value but that would require constant test updates. I may have to make a mock DB for the test API. 
        [Fact]
        public async Task Get_Should_Retrieve_All_Tickets()
        {
            var response = await _client.GetAsync("/api/Ticket/");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ticketList =
                JsonConvert.DeserializeObject<List<Ticket>>(await response.Content.ReadAsStringAsync());
            ticketList.Should().NotContainNulls();

            //var ticketList =
            //    JsonConvert.DeserializeObject<List<Ticket>>(await response.Content.ReadAsStringAsync());
            //ticketList.Should().HaveCount(3);
        }

        //This test checks to make sure a OK status is returned when pulling a single ticket. The ticket id is hard
        //coded in the test :18a6d40b-1422-493a-b7d9-9965ebdc4fdc: which is the Id variable. Unsure if this can be done differently. 
        [Fact]
        public async Task Get_Should_Retrieve_Single_Ticket()
        {
            
            var response = await _client.GetAsync("/api/Ticket/{18a6d40b-1422-493a-b7d9-9965ebdc4fdc}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //var ticket =
            //    JsonConvert.DeserializeObject<Ticket>(await response.Content.ReadAsStringAsync());
            //ticket.Email.Should().Match("ddubose@gmail.com");
        }
        [Fact]
        public async Task Get_Should_Fail_To_Retrieve_Single_Ticket()
        {
            var response = await _client.GetAsync("/api/Ticket/{18a6d40b-1422-493a-b7d9-9965ebdc4fdc}");
            response.StatusCode.Should().NotBe(HttpStatusCode.OK);


        }
        [Fact]
        public async Task Delete_Should_Delete_Ticket()
        {
            var response = await _client.DeleteAsync("/api/Ticket/{34a2b3df-a746-442e-800f-49fbf9157bf0}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
