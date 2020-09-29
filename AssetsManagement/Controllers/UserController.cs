using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AssetsManagement.Repo;
using AssetsManagement.Domain;
using AssetsManagement.Repo.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAssetsManagementRepository _repo;
        public UserController(IAssetsManagementRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = await _repo.GetUserByEmailAndPassword(model.Email, model.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha incorretos" });

            var token = TokenService.GenerateToken(user);
            return new
            {
                user = user,
                token = token
            };
        }

        // GET: api/User
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = await _repo.GetAllUsers();

                return Ok(users);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/User/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await _repo.GetUserById(id);

                return Ok(user);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/User
        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangeAsync())
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest("Não salvou");
        }

        // PUT api/User/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, User model)
        {
            try
            {
                var user = await _repo.GetUserById(id);

                if (user != null)
                {
                    model.Id = user.Id;
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                        return Ok(string.Concat("Usuário atualizado, nome: {0}", user.Name));
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest(string.Concat("Não atualizado, Id informado: {0}", id));
        }

        // DELETE api/User/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _repo.GetUserById(id);

                if (user != null)
                {
                    _repo.Delete(user);
                    if (await _repo.SaveChangeAsync())
                        return Ok(string.Concat("Usuário deletado, Email: {0}", user.Email));
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest(string.Concat("Não Deletado, Id informado: {0}", id));
        }
    }
}
