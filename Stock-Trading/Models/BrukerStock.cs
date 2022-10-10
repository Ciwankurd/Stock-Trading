using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace Stock_Trading.Models
{
    public class BrukerStock
    {
        [Key]
        public int BSId { get; set; }
        public int antallstock { get; set; }
        public string DateAndTime { get; set; }
        virtual public Bruker bruker { get; set; }
        virtual public Stock stock { get; set; }
    }
}
