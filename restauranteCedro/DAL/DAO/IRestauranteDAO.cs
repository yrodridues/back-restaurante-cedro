using System.Collections.Generic;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.DAL.DAO
{
    public interface IRestauranteDAO
    {
        List<Restaurante> GetAll();
        Restaurante GetRestaurante(int id);
        void Inserir(Restaurante restaurante);
        void Update(Restaurante novoRestaurante);
        void Remove(Restaurante restaurante);

    }
}