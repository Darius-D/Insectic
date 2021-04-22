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
        
        public  Task<TicketJsonModel?> GetTicket(int ticketId);
        
        public  void NewTicket(TicketJsonModel ticket);
        

        public   void EditTicket(TicketJsonModel ticket);
        
        public  void DeleteTicket(int ticketId);



    }


}
