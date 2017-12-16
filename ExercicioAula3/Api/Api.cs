using ExercicioAula3.Api.Modelos;
using Modelos;
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

                var resultado = await client
                    .PostAsync("/api/usuario/registrar", conteudo);

                var status = resultado.StatusCode;
                var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                Console.WriteLine($"status: {status} \n conteudo: \n{conteudoResultado}");
            }
        }

        public static async Task<string> LoginUsuario(string email, string senha)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);

                var conteudo = new StringContent(
                        JsonConvert.SerializeObject(new { email, senha })
                        , Encoding.UTF8, "application/json");

                var resultado = await client
                    .PostAsync("/api/usuario/gerartoken", conteudo);

                var status = resultado.StatusCode;
                var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                if (status == System.Net.HttpStatusCode.OK)
                {
                    var token = JsonConvert.DeserializeObject<TokenResposta>(conteudoResultado);
                    return token.Token;
                }

                if (status == System.Net.HttpStatusCode.BadRequest)
                    Console.WriteLine("Usuário e senha incorretos");
            }
            return null;
        }

        public static async Task<List<Lista>> BuscarListaUsuario(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlApi);
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);

                var resultado = await client.GetAsync("/api/lista");

                var status = resultado.StatusCode;
                var conteudoResultado = await resultado.Content.ReadAsStringAsync();

                if (status == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<List<Lista>>(conteudoResultado);

                else
                    Console.WriteLine("Erro ao buscar lista =/");
            }
            return new List<Lista>();
        }
    }
}
