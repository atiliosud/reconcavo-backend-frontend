using System.Collections.Generic;
using WpfApi.Models;

namespace WpfApi.Repository.Interfaces
{
    public interface INeightborhoodRepository
    {
        public List<Neighborhood> Get(string neighborhoodSearch, int size);

        public bool Add(Neighborhood item);
    }
}



