using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetsManagement.Domain;
using AssetsManagement.Repo;
using Microsoft.AspNetCore.Mvc;

namespace AssetsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IAssetsManagementRepository _repo;
        public AssetsController(IAssetsManagementRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Assets
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var assets = await _repo.GetAllAssets();

                return Ok(assets);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // GET api/Assets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var assets = await _repo.GetAssetsById(id);

                return Ok(assets);
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // POST api/Assets
        [HttpPost]
        public async Task<IActionResult> Post(Assets model)
        {
            try
            {
                int assetNumber = await getAssetNumber();

                model.AssetNumber = assetNumber;

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

        // PUT api/Assets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Assets model)
        {
            try
            {
                var assets = await _repo.GetAssetsById(id);

                if (assets != null)
                {
                    model.Id = assets.Id;
                    model.AssetNumber = assets.AssetNumber;
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                        return Ok(string.Concat("Patrimônio atualizado, nome: {0}", assets.Name));
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest(string.Concat("Não atualizado, Id informado: {0}", id));
        }    

        // DELETE api/Assets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var assets = await _repo.GetAssetsById(id);

                if (assets != null)
                {
                    _repo.Delete(assets);
                    if (await _repo.SaveChangeAsync())
                        return Ok(string.Concat("Patrimônio deletado, nome: {0}", assets.Name));
                }
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }

            return BadRequest(string.Concat("Não Deletado, Id informado: {0}", id));
        }

        private async Task<int> getAssetNumber()
        {
            Random randomNumber = new Random();
            int assetNumber = randomNumber.Next();

            while (await _repo.GetAssetsByAssetsNumber(assetNumber) != null)
            {
                assetNumber = randomNumber.Next();
            }

            return assetNumber;
        }
    }
}
