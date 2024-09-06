using Microsoft.EntityFrameworkCore;
using TuristApp2.Data;
using TuristApp2.Interfaces;
using TuristApp2.Models;

namespace TuristApp2.Repository
{
    public class MiejscaRepository : IMiejscaRepository
    {
        private readonly ApplicationDbContext _context;
        public MiejscaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Miejsca miejsca)
        {
            _context.Add(miejsca);
            return Save();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Delete(Miejsca miejsca)
        {
            _context.Remove(miejsca);
            return Save();
        }


        public async Task<IEnumerable<Miejsca>> GetAll()
        {
            return await _context.Miejsca.ToListAsync();
        }

        public async Task<Miejsca> GetByIdAsync(int id)
        {
            return await _context.Miejsca.FirstOrDefaultAsync(i => i.Id == id);
        }

        public bool Save(Miejsca miejsca)
        {
            throw new NotImplementedException();
        }

        public bool Update(Miejsca miejsca)
        {
            throw new NotImplementedException();
        }
    }
}
