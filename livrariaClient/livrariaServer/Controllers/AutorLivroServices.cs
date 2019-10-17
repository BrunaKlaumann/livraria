using livrariaServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace livrariaServer.Controllers
{
    class AutorLivroServices
    {
        public static async Task<List<AutorLivro>> GetDados()
        {
            List<AutorLivro> lista = new List<AutorLivro>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.GetAsync("autorlivro");
            lista = JsonConvert.DeserializeObject<List<AutorLivro>>(await respose.Content.ReadAsStringAsync());

            return lista;
        }
    }
}
