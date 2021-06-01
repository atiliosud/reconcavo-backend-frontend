using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApi.Models
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<DrugStore> DrugStores { get; set; }

        [NotMapped]
        public int MaxResult { get; set; }
    }
}
