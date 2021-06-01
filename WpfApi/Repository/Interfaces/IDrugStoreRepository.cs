using System.Collections.Generic;
using WpfApi.Models;

namespace WpfApi.Repository.Interfaces
{
    public interface IDrugStoreRepository
    {
        public List<DrugStore> Get(int size, string drugStoreName);
        public List<DrugStore> GetByNeightborhood(int idNeighborhood, bool flg_round_the_clock);
        public DrugStore GetById(int id);
        public bool Delete(int id);
        public bool Add(DrugStore drugStore);
        public DrugStore Update(DrugStore drugStore);
    }
}
