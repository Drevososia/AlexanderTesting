using AlexanderTesting.Models;
using AlexanderTesting.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTesting.Repositories
{
    public class PeopleRepository
    {
        private readonly AlexanderTestingBaseContext _context;

        public PeopleRepository(AlexanderTestingBaseContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }
    }
}
