using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldCupAPI.Models
{
    [Table("WorldCupCountry")]
    public class WorldCupCountry
    {
        //É preciso user o Column(Order =) para definir mais de uma chave primaria em uma tabela.
        [Key, Column(Order = 1)]
        public int WorldCupId { get; set; }
        [ForeignKey("WorldCupId")]
        public WorldCup WorldCup { get; set; }

        [Key, Column(Order = 2)]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Required]
        [StringLength(1)]
        public string Group { get; set; }
    }
}