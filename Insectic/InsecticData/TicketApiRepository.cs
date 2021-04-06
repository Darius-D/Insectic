using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insectic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using RestSharp;

namespace Insectic.InsecticData
{
    public class TicketApiRepository :ITicketApiRepository
    {
        private static HttpClient client = new HttpClient();

        public List<TicketJsonModel> GetAllTickets()
        {
            var response = client.GetStringAsync("https://localhost:44342/api/Ticket/");

            List<TicketJsonModel>? ticketList = JsonConvert.DeserializeObject<List<TicketJsonModel>>(response.Result);

                return ticketList;

        }

        public TicketJsonModel GetTicket(string guid)
        {
            
            var response = client.GetStringAsync("https://localhost:44342/api/Ticket/"+guid);

            TicketJsonModel? ticket = JsonConvert.DeserializeObject<TicketJsonModel>(response.Result);

                return ticket;
            
            
        }

        public void AddTicket(TicketJsonModel ticket)
        {
            var client = new RestClient("https://localhost:44342/api/Ticket");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n    \"category\": \"{ticket.Category}\",\r\n    \"priority\": \"{ticket.Priority}\",\r\n    \"status\": \"{ticket.Status}\",\r\n    \"incidentDate\": \"0001-01-01T00:00:00\",\r\n    \"dueDate\": \"0001-01-01T00:00:00\",\r\n    \"phoneNumber\": \"{ticket.PhoneNumber}\",\r\n    \"email\": \"{ticket.Email}\",\r\n    \"ticketDescription\": \"{ticket.TicketDescription}\"\r\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content); ;

        }

        public void EditTicket()
        {
            throw new NotImplementedException();
        }

        public void DeleteTicket()
        {
            throw new NotImplementedException();
        }
    }
}
