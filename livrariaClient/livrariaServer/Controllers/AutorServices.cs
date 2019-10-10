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
    class AutorServices
    {
        public static async Task<List<Autor>> GetAutores()
        {
            List<Autor> lista = new List<Autor>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.GetAsync("autores");
            lista = JsonConvert.DeserializeObject<List<Autor>>(await respose.Content.ReadAsStringAsync());

            return lista;
        }
    }
}
