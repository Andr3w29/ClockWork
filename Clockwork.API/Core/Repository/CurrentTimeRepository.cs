using Clockwork.API.Core.Models;
using Clockwork.API.Interface;
using Clockwork.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clockwork.API.Repository
{
    public class CurrentTimeRepository : ICurrentTimeRepository
    {
    
        public CurrentTimeRepository()
        {
           
        }

        public async Task<int> Add(CurrentTimeQuery currentTimeQuery)
        {
            using (var context = new ClockworkContext())
            {
                context.CurrentTimeQueries.Add(currentTimeQuery);
                return await context.SaveChangesAsync();
            }
               
        }

        public async Task Delete(int CurrentTimeQueryId)
        {
            using (var context = new ClockworkContext())
            {
                var currentTimeQuery = context.CurrentTimeQueries
              .FirstOrDefault(x => x.ID == CurrentTimeQueryId);

                if (currentTimeQuery != null)
                {
                    context.CurrentTimeQueries.Remove(currentTimeQuery);
                    await context.SaveChangesAsync();
                }
            }
              
       
        }

        public async Task<CurrentTimeQuery> Get(int CurrentTimeQueryId)
        {
            using (var context = new ClockworkContext())
            {
                return await context.CurrentTimeQueries
               .FirstOrDefaultAsync(x => x.ID == CurrentTimeQueryId);
            }
               
        }

        public async Task<List<CurrentTimeQuery>> Get()
        {
            using (var context = new ClockworkContext())
            {
                return await context.CurrentTimeQueries.OrderByDescending(x => x.CreatedOn).Take(20).ToListAsync();
            }
             
        } 
        public async Task Update(CurrentTimeQuery currentTimeQuery)
        {
            using (var context = new ClockworkContext())
            {

                if (currentTimeQuery != null)
                {
                    context.CurrentTimeQueries.Update(currentTimeQuery);
                    await context.SaveChangesAsync();
                }
            }

        }
    }
}
