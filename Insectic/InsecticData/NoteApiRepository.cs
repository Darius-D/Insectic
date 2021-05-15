using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insectic.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Insectic.InsecticData
{
    public class NoteApiRepository :INoteRepository
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<List<Note>>? GetAllNotesAsync()
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/Notes/");

            List<Note>? noteList = JsonConvert.DeserializeObject<List<Note>>(response);

            return noteList;
        }

        public async Task<Note?> GetNoteAsyn(int noteId)
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/Notes/" + noteId.ToString());

            Note? note = JsonConvert.DeserializeObject<Note>(response);

            return note;
        }

        public async Task<string> NewNoteAsync(Note note)
        {
            note.UserId = "1";

            var values = JsonConvert.SerializeObject(note);

            var httpContent = new StringContent(values, Encoding.UTF8, "application/json");
            var httpResponse = await Client.PostAsync("https://localhost:44342/api/Notes", httpContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            return responseContent;
        }

        public void DeleteNoteAsync(int noteId)
        {
            var client = new RestClient("https://localhost:44342/api/Notes/" + noteId);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
