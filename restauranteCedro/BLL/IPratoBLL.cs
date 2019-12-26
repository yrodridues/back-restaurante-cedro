using System.Collections.Generic;
using restauranteCedro.DAL.DTO;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.BLL
{
    public interface IPratoBLL
    {
        List<Prato> GetAll();
        Prato GetPrato(int id);
        void Inserir(Prato prato);
        void Update(Prato novoPrato);
        void Remove(int id);
    }
}
