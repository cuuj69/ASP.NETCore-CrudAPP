using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class WorkersController : ControllerBase {

        private static List<Workers> board = new List<Workers>
            {
                new Workers {
                     Id = 1,
                     Position = "Manager",
                     FirstName = "John",
                     LastName = "Afolabi",
                     Location = "Accra"

                },

           new Workers {
                    Id = 2,
                    Position = "Branch Manager",
                    FirstName = "Kweku",
                    LastName = "Adu",
                    Location = "Kumasi"

                }
           };


        [HttpGet]

        public async Task<ActionResult<List<Workers>>> Get()
        {

            return Ok(board);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Workers>> Get(int id)
        {
            var member = board.Find(h => h.Id == id);
            if (member == null)
                return BadRequest("Id does not match any worker");
            return Ok(board);
        }



        [HttpPost]

        public async Task<ActionResult<List<Workers>>> AddWorker(Workers member)
        {
            board.Add(member);
            return Ok(board);
        }

        [HttpPut]
        public async Task<ActionResult<List<Workers>>> UpdateWorker(Workers request)
        {
            var member = board.Find(h => h.Id == request.Id);
            if (member == null)
                return BadRequest("Id does not match any worker");

            member.Position = request.Position;
            member.FirstName = request.FirstName;
            member.LastName = request.LastName;
            member.Location = request.Location;

            return Ok(board);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Workers>>> Delete(int id)
        {
            var member = board.Find(h => h.Id == id);
            if (member == null)
                return BadRequest("Id does not match any worker");

            board.Remove(member);
            return Ok(board);
        }

    }
}

