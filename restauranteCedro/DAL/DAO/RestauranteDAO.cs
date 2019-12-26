using System.Collections.Generic;
using System.Linq;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.DAL.DAO
{
    public class RestauranteDAO : IRestauranteDAO
    {
        private readonly RestauranteContext _context;

        public RestauranteDAO(RestauranteContext context)
        {
            _context = context;
        }

        public List<Restaurante> GetAll()
        {
            var listaRestaurante = _context.Restaurantes.ToList();
            return listaRestaurante;
        }

        public Restaurante GetRestaurante(int id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            return restaurante;
        }

        public void Inserir(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
        }

        public void Remove(Restaurante restaurante)
        {
            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
        }

        public void Update(Restaurante novoRestaurante)
        {
            _context.Restaurantes.Update(novoRestaurante);
            _context.SaveChanges();
        }
    }
}