using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Insectic.Models;
using Insectic.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace Insectic.InsecticData
{
    public static class UserApiRepository 
    {
        private static readonly HttpClient Client = new HttpClient();
       

        public static async Task<List<IdentityUserModel>>? GetAllUsers()
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/User/");

            List<IdentityUserModel>? userList = JsonConvert.DeserializeObject<List<IdentityUserModel>>(response);

            return userList;

        }

        public static async Task<IdentityUserModel?> GetUser(string userId)
        {
            var response = await Client.GetStringAsync("https://localhost:44342/api/User/" + userId);

            var user = JsonConvert.DeserializeObject<IdentityUserModel>(response);
            
            return user;

        }
       
        public static async void AddUser(RegisterModel user)
        {
            var newUser = JsonConvert.SerializeObject(user);
            var httpContent = new StringContent(newUser, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync("https://Localhost:44342/api/User/AddUser", httpContent);
            var responseContent = await response.Content.ReadAsStringAsync();

        }

        //would like to convert from RestSharp to http client. currently having issues with http client method in testing
        public static void EditUser(string userId, IdentityUserModel user)
        {
            var client = new RestClient("https://localhost:44342/api/User/" + userId);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n  \"firstName\": \"{user.FirstName}\",\r\n  \"lastName\": \"{user.LastName}\",\r\n  \"email\": \"{user.Email}\",\r\n  \"contactNumber\": \"{user.PhoneNumber}\",\r\n  \"resourceGroup\": \"{user.ResourceGroup}\",\r\n  \"profilePicture\": \"{user.ProfilePicture}\"\r\n}}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
        }

        public static void DeleteUser(string userId)
        {
            var client = new RestClient("https://localhost:44342/api/User/" + userId);
            client.Timeout = -1;
            var request = new RestRequest(Method.DELETE);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
