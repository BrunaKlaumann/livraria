using livrariaServer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace livrariaServer.Controllers
{
    class LivroServices
    {
        public static async Task<List<Livro>> GetLivros()
        {
            List<Livro> lista = new List<Livro>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.GetAsync("livros");
            lista = JsonConvert.DeserializeObject<List<Livro>>(await respose.Content.ReadAsStringAsync());

            return lista;
        }

        public static async Task<string> PostLivro([FromBody] Livro livro)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);
            HttpResponseMessage response = await client.PostAsJsonAsync("livros", livro);
            return response.StatusCode.ToString();
        }

        public static async Task<string> DeleteLivro(Livro livro)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);
            HttpResponseMessage response = await client.DeleteAsync("livros/" + livro.id_livro);
            return response.StatusCode.ToString();
        }
    }
}
