using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Models;
using Jose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Modelos;

namespace Api.Controllers
{

    [Route("api/Usuario")]
    public class UsuarioController : BaseController
    {
        private readonly IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> BuscarUsuario()
        {
            using (var context = new Context())
            {
                return Ok(await context.Usuarios.FirstOrDefaultAsync(x => x.UsuarioId == GetLoggedUserId()));
            }
        }

        [HttpPost("GerarToken")]
        public async Task<IActionResult> GerarToken([FromBody]ViewModelLogin login)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Email.Trim().ToLower() == login.Email.Trim().ToLower() && x.Senha == login.Senha);

                    if (usuario != null)
                    {
                        var roles = new string[0];

                        var expireDate = DateTime.UtcNow.AddHours(1);

                        var exp = new DateTimeOffset(expireDate);

                        var payload = new Dictionary<string, object>()
                {
                    { "unique_name", usuario.UsuarioId  },
                    { "roles",roles }                ,
                    //{ "company-roles",roles }                ,
                    { "exp", exp.ToUnixTimeSeconds() },
                    { "iss", "flexxo.iss" },
                    { "aud", "flexxo.aud" }
                };

                        var headers = new Dictionary<string, object>();


                        try
                        {
                            var token = JWT.Encode(payload, Convert.FromBase64String(_configuration["TokenSecretKey"]), JwsAlgorithm.HS256, headers);

                            return Ok(new
                            {
                                token,
                                usuario
                            });
                        }
                        catch (Exception e)
                        {
                            throw new Exception("Erro ao gerar token JWT", e);
                        }
                    }
                    ModelState.AddModelError("", "Usuário ou senha inválidos");
                }
            }
            return BadRequest(ModelState);
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody]Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Context())
                {
                    await context.Usuarios.AddAsync(usuario);
                    await context.SaveChangesAsync();
                    return Ok(usuario);
                }
            }
            return BadRequest(ModelState);
        }
    }
}
