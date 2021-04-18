using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insectic.Models;
using Newtonsoft.Json;

namespace Insectic.InsecticData
{
    public interface ITicketRepository
    {

        public  Task<List<TicketJsonModel>>? GetAllTicketsAsync();
        
        public  Task<TicketJsonModel?> GetTicket(string guid);
        
        public  void NewTicket(TicketJsonModel ticket);
        

        public   void EditTicket(int ticketId, TicketJsonModel ticket);
        
        public  void DeleteTicket(int ticketId);



    }


}
