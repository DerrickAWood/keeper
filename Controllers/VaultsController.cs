using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        private readonly KeepsService _ks;

        public VaultsController(VaultsService vs, KeepsService ks)
        {
            _vs = vs;
             _ks = ks;
        }
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Vault>> GetAll()
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("you must be logged in to see vaults");
                }
                return Ok(_vs.GetAll());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

         [HttpGet("{id}")]
        public ActionResult<IEnumerable<Vault>> GetById(int id)
        {
            try
            {
                return Ok(_vs.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }


        [HttpPost]
        [Authorize]
        public ActionResult<Vault> Post([FromBody] Vault newVault)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newVault.UserId = userId;
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("you must be logged in to delete");
                }
            string userId = user.Value;
           return Ok(_vs.Delete(id, userId));
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
     
    }

     [HttpGet("{id}/keeps")]
        public ActionResult<IEnumerable<VaultKeepModel>> GetKeepByVaultId(int id)
        {
            try
            {
                Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("you must be logged in to get by vault id");
                }
            string userId = user.Value;
                return Ok(_ks.GetKeepByVaultId(id, userId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

    }
}