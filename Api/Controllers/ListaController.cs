using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Api.Controllers
{

    [Route("api/Lista")]
    [Authorize]
    public class ListaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AdicionarLista([FromBody]Lista lista)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var usuarioId = GetLoggedUserId();
                    lista.UsuarioId = usuarioId;

                    context.Listas.Add(lista);
                    await context.SaveChangesAsync();

                    return Ok(lista);
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{listaId}")]
        public async Task<IActionResult> BuscarListaDeTarefas(int listaId)
        {
            using (var context = new Context())
            {
                return Ok(await context.Listas.Where(x => x.UsuarioId == GetLoggedUserId() && x.ListaId == listaId).ToListAsync());
            }
        }

        [HttpGet]
        public async Task<IActionResult> BuscarMinhasListas()
        {
            using (var context = new Context())
            {
                return Ok(await context.Listas.Where(x => x.UsuarioId == GetLoggedUserId()).ToListAsync());
            }
        }

    }
}
