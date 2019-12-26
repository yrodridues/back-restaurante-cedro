using System.Collections.Generic;
using restauranteCedro.DAL.Models;

namespace restauranteCedro.DAL.DAO
{
    public interface IPratoDAO
    {
        List<Prato> GetAll();
        Prato GetPrato(int id);
        void Inserir(Prato prato);
        void Update(Prato novoPrato);
        void Remove(Prato prato);

    }
}