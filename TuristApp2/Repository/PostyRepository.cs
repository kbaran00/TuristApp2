using Microsoft.EntityFrameworkCore;
using TuristApp2.Data;
using TuristApp2.Interfaces;
using TuristApp2.Models;

namespace TuristApp2.Repository
{
    public class PostyRepository : IPostyRepository
    {
        private readonly ApplicationDbContext _context;
        public PostyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Posty posty)
        {
            _context.Add(posty);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Delete(Posty posty)
        {
            _context.Remove(posty);
            return Save();
        }


        public async Task<IEnumerable<Posty>> GetAll()
        {       
           return await _context.Posty.Include(x => x.AppUser).ToListAsync();
        }


        public async Task<Posty> GetByIdAsync(int id)
        {
            return await _context.Posty.FirstOrDefaultAsync(i => i.Id == id); ;        
        }

        public bool Save(Posty posty)
        {
            throw new NotImplementedException();
        }

        public bool Update(Posty posty)
        {
            throw new NotImplementedException();
        }
    }
}
