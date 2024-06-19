using Theater.DBModels;

namespace Theater.Services;

public interface IConcessionService
{
    Task<IEnumerable<Concession>> GetConcessions();
}
