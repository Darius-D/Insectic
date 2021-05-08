﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
       

        public static List<UserJsonModel>? GetAllUsers()
        {
            var response = Client.GetStringAsync("https://localhost:44342/api/User/");

            List<UserJsonModel>? userList = JsonConvert.DeserializeObject<List<UserJsonModel>>(response.Result);

            return userList;

        }

        public static UserJsonModel? GetUser(string userId)
        {
            var response = Client.GetStringAsync("https://localhost:44342/api/User/" + userId);

            UserJsonModel? user = JsonConvert.DeserializeObject<UserJsonModel>(response.Result);

            
                return user;

        }

        //public static ObjectResult AddUser(RegisterModel user)
        //{
        //    var response = Client.PostAsync("https://Localhost:44342/api/User")
        //}

        //would like to convert from RestSharp to http client. currently having issues with http client method in testing
        public static void EditUser(string userId, UserJsonModel user)
        {
            var client = new RestClient("https://localhost:44342/api/User/" + userId);
            client.Timeout = -1;
            var request = new RestRequest(Method.PATCH);
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", $"{{\r\n  \"firstName\": \"{user.FirstName}\",\r\n  \"lastName\": \"{user.LastName}\",\r\n  \"email\": \"{user.Email}\",\r\n  \"contactNumber\": \"{user.ContactNumber}\",\r\n  \"userPassword\": \"{user.UserPassword}\",\r\n  \"resourceGroup\": \"{user.ResourceGroup}\",\r\n  \"userRoles\": \"{user.UserRoles}\",\r\n  \"profilePicture\": \"{user.ProfilePicture}\"\r\n}}", ParameterType.RequestBody);
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
