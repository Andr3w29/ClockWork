using Clockwork.API.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clockwork.API.Interface
{
    public interface ICurrentTimeRepository
    {
        Task<int> Add(CurrentTimeQuery currentTimeQuery);
        Task<CurrentTimeQuery> Get(int CurrentTimeQueryId);
        Task<List<CurrentTimeQuery>> Get();
        Task Update(CurrentTimeQuery currentTimeQuery);
        Task Delete(int CurrentTimeQueryId);
    }
}
