using Theater.DBModels;

namespace Theater.Repository;

public interface IConcessionRepository
{
    Task<IEnumerable<Concession>> GetConcessions();
}
