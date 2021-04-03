using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Insectic.Models
{
    public static class Test 
    {
        private static HttpClient client = new HttpClient();


        public static  List<TicketModel>? GetTickets()
        {
            var response = client.GetStringAsync("https://localhost:44342/api/Ticket/");
            Console.WriteLine(response);
            List<TicketModel>? ticketList = JsonConvert.DeserializeObject<List<TicketModel>>(response.ToString());
            
            return ticketList;
            
        }

        
        
            

        public static Task GetTicket()
        {
            throw new NotImplementedException();
        }
    }
}
