using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public static class TicketApiRepository 
    {
        private static readonly HttpClient Client = new HttpClient();

        public static List<TicketJsonModel>? GetAllTickets()
        {
            var response = Client.GetStringAsync("https://localhost:44342/api/Ticket/");

            List<TicketJsonModel>? ticketList = JsonConvert.DeserializeObject<List<TicketJsonModel>>(response.Result);

                return ticketList;

        }

        public static TicketJsonModel? GetTicket(string guid)
        {
            
            var response = Client.GetStringAsync("https://localhost:44342/api/Ticket/"+guid);

            TicketJsonModel? ticket = JsonConvert.DeserializeObject<TicketJsonModel>(response.Result);

                return ticket;
            
            
        }
        public static async void NewTicket(TicketJsonModel ticket)
        {
            var values = JsonConvert.SerializeObject(ticket);
            

            var httpContent = new StringContent(values, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync("https://localhost:44342/api/Ticket", httpContent);
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();

            }


        }
        
        //Would like to change this to httpclient however I can not get my current Http Edit method to work.
        public static void EditTicket(int ticketId, TicketJsonModel ticket)
        {
            var client = new RestClient("https://localhost:44342/api/Ticket/" + ticketId);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n    \"category\": \"{ticket.Category}\",\r\n    \"priority\": \"{ticket.Priority}\",\r\n    \"status\": \"{ticket.Status}\",\r\n    \"ticketDescription\": \"{ticket.TicketDescription}\"\r\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
        }

        public static void DeleteTicket(int ticketId)
        {
            var client = new RestClient("https://localhost:44342/api/Ticket/" + ticketId);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
