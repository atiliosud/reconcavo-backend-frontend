using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WpfApi.Data;
using WpfApi.Models;
using WpfApi.Repository.Interfaces;

namespace WpfApi.Repository
{
    public class DrugStoreRepository: IDrugStoreRepository
    {
        private ReconcavaDbContext _DbContext;

        public DrugStoreRepository(ReconcavaDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        public List<DrugStore> Get(int size, string drugStoreName)
        {
            return string.IsNullOrWhiteSpace(drugStoreName) ? _DbContext.Set<DrugStore>().Take(size).ToList()
                : _DbContext.Set<DrugStore>().Where(x => x.Name.Contains(drugStoreName)).Take(size).ToList();            
        }

        public bool Add(DrugStore item)
        {
             _DbContext.Drugstore.Add(item);
            _DbContext.SaveChanges();
            return true;
        }
        public List<DrugStore> GetByNeightborhood(int idNeighborhood, bool flg_round_the_clock)
        {
            return idNeighborhood == 0 ? _DbContext.Drugstore.Where(x => x.flg_round_the_clock == flg_round_the_clock).ToList():
                _DbContext.Drugstore.Where(x=> x.id_neighborhood == idNeighborhood && x.flg_round_the_clock == flg_round_the_clock).ToList();         
        }
        public bool Delete(int id)
        {
            var item = GetById(id);
            _DbContext.Remove(item);
            _DbContext.SaveChanges();
            return true;
        }

        public DrugStore Update(DrugStore drugStore)
        {
            var result = _DbContext.Update(drugStore);            
            _DbContext.SaveChanges();
            return result.Entity;
        }

        public DrugStore GetById(int id)
        {
            return _DbContext.Set<DrugStore>().Find(id);
        }
    }
}
