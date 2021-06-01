using System.Collections.Generic;

namespace WpfApplication.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<DrugStore> DrugStores { get; set; }
        public int MaxResult { get; set; }
    }
}
