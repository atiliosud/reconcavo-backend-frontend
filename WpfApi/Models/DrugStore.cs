using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace WpfApi.Models
{    
    public class DrugStore
    {
 
        public int Id { get; set; } 
        public string Name { get; set; }
        
        public int id_neighborhood { get; set; }        
        public virtual Neighborhood Neightborhood { get; set; }
        
        public bool flg_round_the_clock { get; set; }
        
        public DateTime foundation_date { get; set; }
        [NotMapped]
        public int MaxResult { get; set; }
    }
}
