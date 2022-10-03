using System.ComponentModel.DataAnnotations;

namespace Stock_Trading.Models
{
    public class SelskapStock
    {
        // heee
        //fghhj
        // Fadle
        public string Id { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string SelskapNavn { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
       
        public string Tegn { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public int AnatallStock { get; set; }
        [RegularExpression(@"[0-9]")]
        public decimal SistePrise { get; set; }
        [RegularExpression(@"[0-9]")]
        public decimal Endring { get; set; }
        [RegularExpression(@"[0-9]")]
        public decimal volume { get; set; } 
    }
}
