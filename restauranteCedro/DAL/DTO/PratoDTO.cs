
namespace restauranteCedro.DAL.DTO
{
    public class PratoDTO
    {
        //Tabela Prato
        public int IdPrato { get; set; }
        public string NomePrato { get; set; }
        public float PrecoPrato { get; set; }

        //Tabela Restaurante
        public int IdRestaurante {get; set;}
        public string NomeRestaurante {get; set;}
    }
}