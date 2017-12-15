using Newtonsoft.Json;

namespace Modelos
{
    public class Lista
    {
        public int ListaId { get; set; }
        public string Nome { get; set; }        
        public int UsuarioId { get; set; }
        [JsonIgnore]
        public Usuario Usuario { get; set; }
    }
}
