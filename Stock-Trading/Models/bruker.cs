using Castle.Components.DictionaryAdapter;
using System.ComponentModel.DataAnnotations;

namespace Stock_Trading.Models
{
    public class Bruker
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int BId { get; set; }

        public string brukernavn { get; set; }
        public string password { get; set; }


    }
}
