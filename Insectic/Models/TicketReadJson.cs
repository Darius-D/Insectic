using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Insectic.Models
{
    public class TicketReadJson
    {

        private static HttpClient _client = new HttpClient();

        //public List<TicketJsonModel> GetTickets()
        //{
        //    var rawJason = _client.GetStringAsync("https://localhost:44342/api/Ticket/");

        //    TicketCollection? ticketCollection = JsonConvert.DeserializeObject<TicketCollection>(rawJason.ToString());
        //}
    }
}
