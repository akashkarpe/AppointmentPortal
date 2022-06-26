using AppointmentWebPortal.Models;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Configuration;

namespace AppointmentWeb.Utility
{
    public class APIHelper
    {
        string BaseUrl;
        public APIHelper()
        {
            BaseUrl = Convert.ToString(WebConfigurationManager.AppSettings[Constants.APIUrl]);
        }

        public string GetTokenFromSession()
        {
            string token = string.Empty;
            SessionUtility sessionUtility = new SessionUtility();
            var loginObj = sessionUtility.GetValueFromSession(Constants.LoginResponse);
            if (loginObj != null)
            {
                LoginResponse loginResponse = (LoginResponse)loginObj;
                token = loginResponse.Token;
            }
            return token;
        }
        public Response GetData(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenFromSession());
            client.BaseAddress = new Uri(BaseUrl);
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            HttpResponseMessage response = client.GetAsync(url).Result;  // Blocking call!
            var content = response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response>(content.Result);
            return result;
        }

        public Response PostData(string url,object data)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response result = new Response();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenFromSession());
                client.BaseAddress = new Uri(BaseUrl);
                response = client.PostAsJsonAsync(url, data).Result;
                var content = response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Response>(content.Result);
            }
            return result;
        }

        public Response PutData(string url, object data)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response result = new Response();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenFromSession());
                client.BaseAddress = new Uri(BaseUrl);
                response = client.PutAsJsonAsync(url, data).Result;
                var content = response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Response>(content.Result);
            }
            return result;
        }

        public Response DeleteData(string url)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            Response result = new Response();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenFromSession());
                client.BaseAddress = new Uri(BaseUrl);
                response = client.DeleteAsync(url).Result;
                var content = response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<Response>(content.Result);
            }
            return result;
        }
    }
}