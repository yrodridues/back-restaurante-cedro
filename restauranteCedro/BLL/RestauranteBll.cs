using System.Collections.Generic;
using restauranteCedro.BLL;
using restauranteCedro.DAL.DAO;
using restauranteCedro.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace restauranteCedro.BLL
{
    public class RestauranteBLL : IRestauranteBLL
    {
        public readonly IRestauranteDAO _restauranteDAO;

        public RestauranteBLL(IRestauranteDAO restauranteDAO)
        {
            _restauranteDAO = restauranteDAO;
        }

        //REGRA DE NEGOCIO PARA OBTENCAO DE TODOS RESTAURANTES
        public List<Restaurante> GetAll()
        {
            var listaRestaurantes = _restauranteDAO.GetAll();

            return listaRestaurantes;
        }

        //REGRA DE NEGOCIO PARA OBTENCAO DE RESTAURANTE POR ID
        public Restaurante GetRestaurante(int id)
        {
            var restaurante = _restauranteDAO.GetRestaurante(id);

            return restaurante;
        }
        
        //REGRA DE NEGOCIO PARA INSERCAO DE UM NOVO RESTAURANTE
        public void Inserir(Restaurante restaurante)
        {
            _restauranteDAO.Inserir(restaurante);
        }

        //REGRA DE NEGOCIO PARA REMOCAO DE UM RESTAURANTE
        public void Remove(int id)
        {
            var obj = _restauranteDAO.GetRestaurante(id);
            bool hasAny = obj != null;
            if (!hasAny)
            {
                throw new KeyNotFoundException("Id não encontrado.");
            }

            try
            {
                _restauranteDAO.Remove(obj);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }

        //REGRA DE NEGOCIO PARA A UTUALIZACAO DOS DADOS DE UM RESTAURANTE
        public void Update(Restaurante novoRestaurante)
        {
            var objAtual = _restauranteDAO.GetRestaurante(novoRestaurante.IdRestaurante);
            bool hasAny = objAtual != null;
            if (!hasAny)
            {
                throw new KeyNotFoundException("Id não encontrado.");
            }
            objAtual.NomeRestaurante = novoRestaurante.NomeRestaurante;

            try
            {
                _restauranteDAO.Update(objAtual);
            }
            catch (System.Exception ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
    }
}