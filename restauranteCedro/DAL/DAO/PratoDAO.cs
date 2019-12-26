using System.Collections.Generic;
using System.Linq;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.DAL.DAO
{
    public class PratoDAO : IPratoDAO
    {
        private readonly RestauranteContext _context;

        public PratoDAO(RestauranteContext context)
        {
            _context = context;
        }

        public List<Prato> GetAll()
        {
            var listaPratos = _context.Pratos.ToList();
            return listaPratos;
        }

        public Prato GetPrato(int id)
        {
            var pratos = _context.Pratos.Find(id);
            return pratos;
        }

        public void Inserir(Prato prato)
        {
            _context.Pratos.Add(prato);
            _context.SaveChanges();
        }

        public void Remove(Prato prato)
        {
            _context.Pratos.Remove(prato);
            _context.SaveChanges();
        }

        public void Update(Prato novoPrato)
        {
            _context.Pratos.Update(novoPrato);
            _context.SaveChanges();
        }
    }
}