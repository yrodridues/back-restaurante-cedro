using System.Collections.Generic;
using restauranteCedro.BLL;
using restauranteCedro.DAL.DAO;
using restauranteCedro.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranteCedro.BLL
{
    public class PratoBLL : IPratoBLL
    {
        public readonly IPratoDAO _pratoDAO;

        public PratoBLL(IPratoDAO pratoDAO)
        {
            _pratoDAO = pratoDAO;
        }

        //REGRA DE NEGOCIO PARA A OBTENCAO DE TODOS OS PRATOS
        public List<Prato> GetAll()
        {
            var listaPratos = _pratoDAO.GetAll();
            return listaPratos;
        }

        //REGRA DE NEGOCIO PARA A OBTENCAO DE UM PRATO POR ID
        public Prato GetPrato(int id)
        {
            var prato = _pratoDAO.GetPrato(id);
            return prato;
        }

        //REGRA DE NEGOCIO PARA INSERCAO DE UM NOVO PRATO
        public void Inserir(Prato prato)
        {
            _pratoDAO.Inserir(prato);
        }

        //REGRA DE NEGOCIO PARA REMOCAO DE UM PRATO
        public void Remove(int id)
        {
             var obj = _pratoDAO.GetPrato(id);
            bool hasAny = obj != null;
            if (!hasAny)
            {
                throw new KeyNotFoundException("Id não encontrado.");
            }

            try
            {
                _pratoDAO.Remove(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        //REGRA DE NEGOCIO PARA A ATUALIZACAO DOS DADOS DE UM PRATO
        public void Update(Prato novoPrato)
        {
            var objAtual = _pratoDAO.GetPrato(novoPrato.IdPrato);
            bool hasAny = objAtual != null;
            if (!hasAny)
            {
                throw new KeyNotFoundException("Id não encontrado.");
            }
            objAtual.NomePrato = novoPrato.NomePrato;
            objAtual.PrecoPrato = novoPrato.PrecoPrato;
            objAtual.IdRestaurante = novoPrato.IdRestaurante;

            try
            {
                _pratoDAO.Update(objAtual);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}
