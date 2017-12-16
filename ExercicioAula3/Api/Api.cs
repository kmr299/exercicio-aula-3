using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula3.Api
{
    public static class Api
    {
        private static string UrlApi = "http://localhost:55449";

        public static async Task RegistrarUsuario(string nome, string email, string senha)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);

                var conteudo = new StringContent(
                        JsonConvert.SerializeObject(new { nome, email, senha })
                        , Encoding.UTF8, "application/json");

                var resultado =                    await client
                    .PostAsync("/api/usuario/registrar", conteudo);

                var status = resultado.StatusCode;
                var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                Console.WriteLine($"status: {status} \n conteudo: \n{conteudoResultado}");
            }
        }

    }
}
