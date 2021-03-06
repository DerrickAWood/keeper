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
    public class KeepsController : ControllerBase
    {
        private readonly KeepsService _ks;
        public KeepsController(KeepsService ks)
        {
            _ks = ks;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Keep>> Get()
        {
            try
            {
                return Ok(_ks.Get());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Keep>> GetById(int id)
        {
            try
            {
                return Ok(_ks.GetById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            };
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Keep> Post([FromBody] Keep newKeep)
        {
            try
            {
                var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                newKeep.UserId = userId;
                return Ok(_ks.Create(newKeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Keep> Edit(int id, [FromBody] Keep keepToUpdate)
        {
            try
            {
               keepToUpdate.Id = id;
               Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                if (user == null)
                {
                    throw new Exception("you must be logged in");
                }
                string userId = user.Value;
                return Ok(_ks.Edit(keepToUpdate, userId));
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
           return Ok(_ks.Delete(id, userId));
      }
      catch (System.Exception error)
      {
          return BadRequest(error.Message);
      }
     
    }

    }
}