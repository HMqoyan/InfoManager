using InfoManager.Data.Models;
using InfoManager.Data.Repositories;
using InfoManager.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IGenericRepository<Person> _repository;

        public PeopleController(IGenericRepository<Person> repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPeople()
        {
            var data = await this._repository.ListAsync();

            return data.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await this._repository.GetByIdAsync(id);

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
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            var validator = new PersonValidator();
            
            if (!validator.Validate(person).IsValid)
            {
                return BadRequest();
            }

            await this._repository.AddAsync(person);

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> DeletePerson(int id)
        {
            var person = await this._repository.GetByIdAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            await this._repository.DeleteAsync(person);

            return person;
        }
    }
}
