using Endpoint.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Endpoint.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient client;

        public CatFactService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<CatFact> GetCatFact()
        {
            var response = await client.GetAsync("https://catfact.ninja/fact");

            if(!response.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                var result = response.Content.ReadAsStringAsync();

                var fact = JsonConvert.DeserializeObject<CatFact>(result.Result);

                return fact;
            }
        }

        public async Task<bool> SaveCatFact(CatFact fact)
        {
            using (StreamWriter sw = new StreamWriter("catfacts.txt", true))
            {
                await sw.WriteLineAsync("Fact: " + fact.Fact + ", Length: " + fact.Length);
            }

            return true;
        }
    }
}
