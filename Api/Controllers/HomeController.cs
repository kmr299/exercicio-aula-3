using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public async Task<IActionResult> Get()
        {
            using (var context = new Context())
            {
                return Ok(new
                {
                    Usuarios = context.Usuarios.ToListAsync(),
                    Listas = context.Listas.ToListAsync(),
                    Tarefas = context.Tarefas.ToListAsync()
                });
            }
        }
    }
}
