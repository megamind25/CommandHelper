using System.Collections.Generic;
using AutoMapper;
using CommandHelper.Data;
using CommandHelper.Dtos;
using CommandHelper.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandHelper.Controllers
{
    [Route("/api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandHelperRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandHelperRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        //GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        //GET api/commands/5
        [HttpGet("{Id}", Name="GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int Id)
        {
            var command = _repository.GetCommandById(Id);
            if(command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }
            return NotFound();
        }

        //POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();
            
            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), new {Id = commandReadDto.ID}, commandReadDto);

        }

        //PUT api/commands/{id}
        [HttpPut("{Id}")]
        public ActionResult UpdateCommand(int Id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(Id);
            if(commandModelFromRepo == null)
                return NotFound();
            
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        //PATCH api/commands/{id}
        [HttpPatch("{Id}")]
        public ActionResult PartialCommandUpdate(int Id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommandById(Id);
            if(commandModelFromRepo == null)
                return NotFound();
            
            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);
            patchDoc.ApplyTo(commandToPatch, ModelState);

            if(!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }

        //DELETE api/commands/{id}
        [HttpDelete("{Id}")]
        public ActionResult DeleteCommand(int Id)
        {
            var commandModelFromRepo = _repository.GetCommandById(Id);
            if(commandModelFromRepo == null)
                return NotFound();

            _repository.DeleteCommand(commandModelFromRepo);

            _repository.SaveChanges();
            
            return NoContent();
        }

    }
}