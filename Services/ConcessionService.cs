using Theater.DBModels;
using Theater.Repository;

namespace Theater.Services;

public class ConcessionService : IConcessionService
{
    private readonly IConcessionRepository concessionRepository;

    public ConcessionService(IConcessionRepository concessionRepository)
    {
        this.concessionRepository = concessionRepository;
    }

    public async Task<IEnumerable<Concession>> GetConcessions()
    {
        return await concessionRepository.GetConcessions();
    }
}
