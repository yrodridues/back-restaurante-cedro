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

        //OBTEM TODOS OS RESTAURANTES CADASTRADOS
        public List<Restaurante> GetAll()
        {
            var listaRestaurante = _context.Restaurantes.ToList();
            return listaRestaurante;
        }
        
        //OBTEM UM RESTAURANTE ATRAVEZ DO SEU ID
        public Restaurante GetRestaurante(int id)
        {
            var restaurante = _context.Restaurantes.Find(id);
            return restaurante;
        }

        //INSERE UM NOVO RESTAURANTE NO BANCO
        public void Inserir(Restaurante restaurante)
        {
            _context.Restaurantes.Add(restaurante);
            _context.SaveChanges();
        }
        
        //REMOVE UM RESTAURANTE DO BANCO
        public void Remove(Restaurante restaurante)
        {
            _context.Restaurantes.Remove(restaurante);
            _context.SaveChanges();
        }

        //ATUALIZA OS DADOS DE UM RESTAURANTE
        public void Update(Restaurante novoRestaurante)
        {
            _context.Restaurantes.Update(novoRestaurante);
            _context.SaveChanges();
        }
    }
}