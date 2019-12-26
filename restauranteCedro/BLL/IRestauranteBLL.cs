using System.Collections.Generic;
using restauranteCedro.DAL.DTO;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.BLL
{
    public interface IRestauranteBLL
    {
        List<Restaurante> GetAll();
        Restaurante GetRestaurante(int id);
        void Inserir(Restaurante restaurante);
        void Update(Restaurante novoRestaurante);
        void Remove(int id);
    }
}
