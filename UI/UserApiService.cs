using Api.Models;
using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace UI
{
    public class UserApiService
    {

        private string GetJwtToken(string username, string password)
        {
            string token = "54cae980-2b56-4144-bbfb-c81a3eb031fa";
            return token;
        }
        public User Put()
        {
            string accessToken = GetJwtToken("admin", "1234");
            HttpClient httpClient = new HttpClient();
            User user = new User()
            {
                UserId = 4,
                Age = 20,
                Name = "mahsa",
                SurName = "adeli",
                UserName="mahsaAdeli",
                Password= "123"
            };
            string content = JsonConvert.SerializeObject(user);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");

            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            var response =  httpClient.PutAsync("http://localhost:54527/Api/User", data).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(responseContent);
        }
        public int Post()
        {
            HttpClient httpClient = new HttpClient();
            User user = new User()
            {
                UserId = 6,
                Name = "shima",
                SurName = "shahi",
                Age = 20,
                UserName="shimashahi",
                Password= "123"
                

            };
            string content = JsonConvert.SerializeObject(user);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");


            var response =httpClient.PostAsync("http://localhost:54527/Api/User", data).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            return int.Parse(responseContent);
        }

        public List<User> GetAll()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("http://localhost:54527/Api/User").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            List<User> result = JsonConvert.DeserializeObject<List<User>>(content);
            return result;
        }
        public User Get(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync($"http://localhost:54527/Api/User/{id}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            User result = JsonConvert.DeserializeObject<User>(content);
            return result;
        }

        public void Delete(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"http://localhost:54527/Api/User/{id}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
        }
    }
}
