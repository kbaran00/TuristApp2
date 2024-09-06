using TuristApp2.Models;

namespace TuristApp2.Interfaces
{
    public interface IPostyRepository
    {
        Task<IEnumerable<Posty>> GetAll();
        Task<Posty> GetByIdAsync(int id);

        bool Add(Posty posty);
        bool Update(Posty posty);

        bool Delete(Posty posty);

        bool Save(Posty posty);
    }
}
