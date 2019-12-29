using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.DAL.DAO
{
    public class SeedingService
    {
        private readonly RestauranteContext _context;

        public SeedingService(RestauranteContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Restaurantes.ToList().Count != 0)
            {
                return; //DB has been seeded
            }

            //Add Restaurante
            Restaurante restaurante1 = new Restaurante();
            restaurante1.NomeRestaurante = "D";

            List<Restaurante> restaurantes = new List<Restaurante>();
            restaurantes.Add(restaurante1);

            _context.Restaurantes.AddRange(restaurantes);
            _context.SaveChanges();

            //Add Prato
            Prato prato1 = new Prato();
            prato1.IdRestaurante = 1;
            prato1.NomePrato = "Paella Mineira";
            prato1.PrecoPrato = 20;

            List<Prato> pratos = new List<Prato>();
            pratos.Add(prato1);

            _context.Pratos.AddRange(pratos);
            _context.SaveChanges();
        }
    }
}