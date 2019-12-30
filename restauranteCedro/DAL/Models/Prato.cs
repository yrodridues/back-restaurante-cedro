using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauranteCedro.DAL.Models
{
    [Table ("Prato")]
    public class Prato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrato { get; set; }

        public string NomePrato { get; set; }

        public float PrecoPrato { get; set; }

        public int IdRestaurante {get; set;}
        public Restaurante Restaurante {get; set;}
    }
}