using System.Collections.Generic;
using System.Linq;
using WpfApi.Data;
using WpfApi.Models;
using WpfApi.Repository.Interfaces;

namespace WpfApi.Repository
{
    public class NeightborhoodRepository: INeightborhoodRepository
    {

        private ReconcavaDbContext _DbContext;

        public NeightborhoodRepository(ReconcavaDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        public List<Neighborhood> Get(string neighborhoodSearch, int size)
        {
            return string.IsNullOrWhiteSpace(neighborhoodSearch) ? _DbContext.Set<Neighborhood>().Take(size).ToList()
                : _DbContext.Set<Neighborhood>().Where(x => x.Name.Contains(neighborhoodSearch)).Take(size).ToList();
        }

        public bool Add(Neighborhood item)
        {
            _DbContext.Neightborhood.Add(item);
            _DbContext.SaveChanges();
            return true;
        }
    }
}
