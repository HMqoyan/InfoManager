using AutoMapper;
using InfoManager.BLL;
using InfoManager.Data.Models;
using InfoManager.Data.Repositories;
using InfoManager.Validation;
using InfoManager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IGenericRepository<Person> _repository;
        private readonly IMapper _mapper;
        public PeopleController(IGenericRepository<Person> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonViewModel>>> GetPeople()
        {
            var bl = new PersonBL(this._repository, this._mapper);

            return await bl.GetPeopleFullModel();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonViewModel>> GetPerson(int id)
        {
            var bl = new PersonBL(this._repository, this._mapper);
            var person = await bl.GetPersonFullModel(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> EditPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            var validator = new PersonValidator();

            if (!validator.Validate(person).IsValid)
            {
                return BadRequest();
            }

            try
            {
                await this._repository.EditAsync(person);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (this._repository.GetByIdAsync(id) is null)
                {
                    return NotFound();
                }
                else
                {
                    return Problem();
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PersonViewModel>> CreatePerson(Person person)
        {
            var validator = new PersonValidator();

            if (!validator.Validate(person).IsValid)
            {
                return BadRequest();
            }

            await this._repository.AddAsync(person);

            var viewModel = this._mapper.Map<Person, PersonViewModel>(person);

            return CreatedAtAction("GetPerson", new { id = person.Id }, viewModel);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonViewModel>> DeletePerson(int id)
        {
            var person = await this._repository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await this._repository.DeleteAsync(person);
            var viewModel = this._mapper.Map<Person, PersonViewModel>(person);

            return viewModel;
        }
    }
}
