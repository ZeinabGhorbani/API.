using Common.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace EndPoint.Helper
{
    public class UserApiService
    {
        public User Put(User user)
        {
            HttpClient httpClient = new HttpClient();

            string content = JsonConvert.SerializeObject(user);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");


            var response =
                httpClient.PutAsync("http://localhost:54527/Api/User", data).Result;
            string responseContent = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<User>(responseContent);
        }
        public int Post(User user)
        {
            HttpClient httpClient = new HttpClient();

            string content = JsonConvert.SerializeObject(user);
            HttpContent data = new StringContent(content, Encoding.UTF8, "application/json");


            var response =
                httpClient.PostAsync("http://localhost:54527/Api/User", data).Result;
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

        public void DeleteUser(int id)
        {
            HttpClient client = new HttpClient();
            var response = client.DeleteAsync($"http://localhost:54527/Api/User/{id}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
        }
    }
}
