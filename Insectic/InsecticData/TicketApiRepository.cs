using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insectic.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Insectic.InsecticData
{
    public class TicketApiRepository : ITicketRepository
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<List<TicketJsonModel>>? GetAllTicketsAsync()
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/Ticket/");
            
            List<TicketJsonModel>? ticketList = JsonConvert.DeserializeObject<List<TicketJsonModel>>(response);

                return ticketList!;

        }

        public async Task<TicketJsonModel?> GetTicket(int ticketId)
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/Ticket/"+ ticketId.ToString());

            TicketJsonModel? ticket = JsonConvert.DeserializeObject<TicketJsonModel>(response);

                return ticket;
        }

        public  async void NewTicket(TicketJsonModel ticket)
        {
            var values = JsonConvert.SerializeObject(ticket);
            
            var httpContent = new StringContent(values, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync("https://localhost:44342/api/Ticket", httpContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

        }
        
        public  async void EditTicket(int ticketId, TicketJsonModel ticket)
        {

            var values = JsonConvert.SerializeObject(ticket);


            var httpContent = new StringContent(values, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PatchAsync("https://localhost:44342/api/Ticket" + ticketId, httpContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            return;


            //var client = new RestClient("https://localhost:44342/api/Ticket/" + ticketId);
            //client.Timeout = -1;
            //var request = new RestRequest(Method.PATCH);
            //request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", $"{{\r\n    \"category\": \"{ticket.Category}\",\r\n    \"priority\": \"{ticket.Priority}\",\r\n    \"status\": \"{ticket.Status}\",\r\n    \"ticketDescription\": \"{ticket.TicketDescription}\"\r\n}}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

        }

        public  void DeleteTicket(int ticketId)
        {
            var client = new RestClient("https://localhost:44342/api/Ticket/" + ticketId);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
