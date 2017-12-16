using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicioAula3.Api.Modelos
{
    public class TokenResposta
    {
        public string Token { get; set; }
        public Usuario Usuario { get; set; }
    }
}
