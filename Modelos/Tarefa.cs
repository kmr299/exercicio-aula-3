using Newtonsoft.Json;
using System;

namespace Modelos
{

    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Nome { get; set; }
        public bool Concluida { get; set; }
        [JsonIgnore]
        public Lista Lista { get; set; }
        public int ListaId { get; set; }

        public Tarefa()
        {
            Concluida = false;
        }
    }
}
