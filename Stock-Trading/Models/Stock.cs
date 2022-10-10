using System.ComponentModel.DataAnnotations;

namespace Stock_Trading.Models
{
    public class Stock
    {
        [Key]
        public int SId { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public string SelskapNavn { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]

        public string Tegn { get; set; }
        [RegularExpression(@"[a-zA-ZæøåÆØÅ. \-]{2,20}")]
        public int AntallStock { get; set; }
        [RegularExpression(@"[0-9]")]
        public double SistePrise { get; set; }
        [RegularExpression(@"[0-9]")]
        public double Endring { get; set; }
        [RegularExpression(@"[0-9]")]
        public double volume { get; set; }
    }
}
