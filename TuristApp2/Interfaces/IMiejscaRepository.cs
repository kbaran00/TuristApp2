using TuristApp2.Models;

namespace TuristApp2.Interfaces
{
    public interface IMiejscaRepository
    {
        Task<IEnumerable<Miejsca>> GetAll();
        Task<Miejsca> GetByIdAsync(int id);

        bool Add(Miejsca miejsca);

        bool Update(Miejsca miejsca);

        bool Delete(Miejsca miejsca);

        bool Save (Miejsca miejsca);
    }
}
