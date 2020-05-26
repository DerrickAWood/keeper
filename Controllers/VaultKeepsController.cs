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
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultKeepsService _vks;

        public VaultKeepsController(VaultKeepsService vks)
        {
            _vks = vks;
        }   
        [HttpGet]
        public ActionResult<IEnumerable<VaultKeep>> Get()
        {
            try
            {
                return Ok(_vks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        

        [HttpPost]
        public ActionResult<VaultKeep> Post([FromBody] VaultKeep newVaultKeep)
        {
            try
            {
                // var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                // newVaultKeep.UserId = userId;
                return Ok(_vks.Create(newVaultKeep));
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
    //        return Ok(_vks.Delete(id, userId));
    //   }
    //   catch (System.Exception error)
    //   {
    //       return BadRequest(error.Message);
    //   }
     
    // }

    }
}