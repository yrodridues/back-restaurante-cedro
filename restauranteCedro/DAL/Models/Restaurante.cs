using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace restauranteCedro.DAL.Models
{
    [Table ("Restaurante")]
    public class Restaurante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRestaurante { get; set; }

        public string NomeRestaurante{ get; set; }

        public ICollection<Prato> Pratos { get; set; }
    }
}