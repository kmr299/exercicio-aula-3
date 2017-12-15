using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos;

namespace Api.Controllers
{
    [Route("api/Lista/")]
    [Authorize]
    public class TarefaController : BaseController
    {

        [HttpPost("{listaId}/tarefa")]
        public async Task<IActionResult> AdicionarTarefa([FromRoute]int listaId, [FromBody]Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    if (await context.Listas.AnyAsync(x => x.ListaId == listaId))
                    {

                        tarefa.ListaId = listaId;
                        context.Add(tarefa);
                        await context.SaveChangesAsync();

                        return Ok(tarefa);
                    }
                    ModelState.AddModelError("", "Lista de Tarefas inválida");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpGet("{listaId}/tarefa")]
        public async Task<IActionResult> BuscarTarefas([FromRoute]int listaId)
        {
            using (var context = new Context())
            {
                return Ok(await context.Tarefas.Where(x => x.ListaId == listaId).ToListAsync());
            }
        }


        [HttpGet("{listaId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> BuscarTarefa([FromRoute]int listaId, [FromRoute]int tarefaId)
        {
            using (var context = new Context())
            {
                return Ok(await context.Tarefas.Where(x => x.ListaId == listaId && x.TarefaId == tarefaId).FirstOrDefaultAsync());
            }
        }
        [HttpPost("{listaId}/tarefa/{tarefaId}/concluir")]
        public async Task<IActionResult> ConcluirTarefa([FromRoute]int listaId, [FromRoute]int tarefaId)
        {
            using (var context = new Context())
            {
                var tarefa = await context.Tarefas.Where(x => x.ListaId == listaId && x.TarefaId == tarefaId).FirstOrDefaultAsync();
                if (tarefa == null)
                    return NotFound();

                tarefa.Concluida = true;
                await context.SaveChangesAsync();
                return Ok(tarefa);
            }
        }
        [HttpPost("{listaId}/tarefa/{tarefaId}/naoconcluir")]
        public async Task<IActionResult> NaoConcluirTarefa([FromRoute]int listaId, [FromRoute]int tarefaId)
        {
            using (var context = new Context())
            {
                var tarefa = await context.Tarefas.Where(x => x.ListaId == listaId && x.TarefaId == tarefaId).FirstOrDefaultAsync();
                if (tarefa == null)
                    return NotFound();

                tarefa.Concluida = false;
                await context.SaveChangesAsync();
                return Ok(tarefa);
            }
        }

        [HttpDelete("{listaId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> RemoverTarefa([FromRoute]int listaId, [FromRoute]int tarefaId)
        {
            using (var context = new Context())
            {
                var tarefa = await context.Tarefas.Where(x => x.ListaId == listaId && x.TarefaId == tarefaId).FirstOrDefaultAsync();
                if (tarefa == null)
                    return NotFound();

                context.Remove(tarefa);
                await context.SaveChangesAsync();
                return Ok(tarefa);
            }
        }

        [HttpPut("{listaId}/tarefa/{tarefaId}")]
        public async Task<IActionResult> AlterarTarefa([FromRoute]int listaId, [FromRoute] int tarefaId, [FromBody]Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    if (await context.Listas.AnyAsync(x => x.ListaId == listaId))
                    {
                        var tarefaBanco = await context.Tarefas.Where(x => x.ListaId == listaId && x.TarefaId == tarefaId).FirstOrDefaultAsync();
                        if (tarefaBanco == null)
                            return NotFound();

                        tarefaBanco.Nome = tarefa.Nome;
                        
                        await context.SaveChangesAsync();
                        return Ok(tarefa);
                    }
                    ModelState.AddModelError("", "Lista de Tarefas inválida");
                }
            }
            return BadRequest(ModelState);
        }
    }
}
