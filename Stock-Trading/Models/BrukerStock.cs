using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock_Trading.Models
{
    public class BrukerStock
    {
        [Key]
        public int BSId { get; set; }
        public int antallstock { get; set; }
        public string DateAndTime { get; set; }
        public int BId { get; set; }
        public int SId { get; set; }
        [ForeignKey("BId")]
        virtual public Bruker bruker { get; set; }
        [ForeignKey("SId")]
        virtual public Stock stock { get; set; }
    }
}
