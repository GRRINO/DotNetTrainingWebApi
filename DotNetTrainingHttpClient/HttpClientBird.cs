using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DotNetTrainingHttpClient
{
    public class HttpClientBird
    {
        private readonly HttpClient _client;

        public HttpClientBird()
        {
            _client = new HttpClient();
        }

        public async Task Read()
        {
            var response = await _client.GetAsync("https://brids-crud-sample.vercel.app/api/v1/birds");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var birds = JsonSerializer.Deserialize<List<tblBird>>(json);

            foreach (var bird in birds)
            {
                Console.WriteLine($"{bird.Id} | {bird.BirdEnglishName} | {bird.BirdMyanmarName}");
            }
        }

        public async Task CreatePostAsync(tblBird bird)
        {
            var json = JsonSerializer.Serialize(bird);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("https://brids-crud-sample.vercel.app/api/v1/birds", content);
            response.EnsureSuccessStatusCode();



            Console.WriteLine("Create Successful");
        }

        public async Task UpdatePostAsync(int id, tblBird bird)
        {
            var json = JsonSerializer.Serialize(bird);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PatchAsync($"https://brids-crud-sample.vercel.app/api/v1/birds/{id}", content);
            response.EnsureSuccessStatusCode();

            // response ကို ဒီနေရာမှာ ကိုင်တွယ်နိုင်ပါတယ်
            Console.WriteLine("Update Successful");

        }

        public async Task DeletePostAsync(int id)
        {
            var response = await _client.DeleteAsync($"https://brids-crud-sample.vercel.app/api/v1/birds/{id}");
            response.EnsureSuccessStatusCode();

            // response ကို ဒီနေရာမှာ ကိုင်တွယ်နိုင်ပါတယ်
            Console.WriteLine("Delete Successful");
        }
    }

    public class tblBird
    {
        public int Id { get; set; }
        public string BirdMyanmarName { get; set; }
        public string BirdEnglishName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
