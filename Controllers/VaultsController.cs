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


// ANCHOR get vaults route to work
namespace Keepr.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> GetAll()
        {
            try
            {
                return Ok(_vs.GetAll());
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






    // [Authorize]
    // [HttpDelete("{id}")]
    // public ActionResult<string> Delete(int id)
    // {
    //   try
    //   {
    //     Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
    //             if (user == null)
    //             {
    //                 throw new Exception("you must be logged in to delete");
    //             }
    //         string userId = user.Value;
    //        return Ok(_ks.Delete(id, userId));
    //   }
    //   catch (System.Exception error)
    //   {
    //       return BadRequest(error.Message);
    //   }
     
    // }

    }
}