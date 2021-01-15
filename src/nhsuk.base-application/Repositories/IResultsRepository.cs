using System.Collections.Generic;
using System.Threading.Tasks;
using nhsuk.base_application.Models;

namespace nhsuk.base_application.Repositories
{
    public interface IResultsRepository
    {
        Task<List<Result>> GetResults(string org);
    }
}