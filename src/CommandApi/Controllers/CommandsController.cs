using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CommandAPI.Models;
using CommandAPI.Data;

namespace CommandAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private ICommandAPIRepo _repository;
        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //return new string[] {"this", "is", "hard", "coded"};
            return Ok(_repository.GetAllCommands());
        }
        [HttpGet("{id}")]
        public ActionResult GetCommandById(int id)
        {
            Command command = _repository.GetCommandById(id);
            if(command == null)
            {
                return NotFound();
            }
            return Ok(command);
        }
    }
}