using InfoManager.Data.Contexts;
using InfoManager.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfoManager.Data.Repositories
{
    public class PeopleRepository : IGenericRepository<Person>
    {
        private readonly PeopleDBContext _context;
        public PeopleRepository(PeopleDBContext ctx)
        {
            this._context = ctx;
        }

        public async Task AddAsync(Person entity)
        {
            _context.People.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Person entity)
        {
            this._context.People.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Person entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;

            await this._context.SaveChangesAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await this._context.People.FindAsync(id);
        }

        public async Task<IEnumerable<Person>> ListAsync()
        {
            return await this._context.People.ToListAsync();
        }
    }
}
