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
    class UsuarioServices
    {
        public static async Task<List<Usuario>> GetUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44306/api/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);

            HttpResponseMessage respose = await client.GetAsync("usuarios");
            lista = JsonConvert.DeserializeObject<List<Usuario>>(await respose.Content.ReadAsStringAsync());

            return lista;
        }
    }
}
