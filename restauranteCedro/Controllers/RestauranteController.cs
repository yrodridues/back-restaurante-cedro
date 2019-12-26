using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using restauranteCedro.BLL;
using restauranteCedro.DAL.DTO;
using restauranteCedro.Utils;
using Newtonsoft.Json;
using System.Threading.Tasks;
using restauranteCedro.DAL.Models;
using restauranteCedro.Extensions.Responses;
using AutoMapper;

namespace restauranteCedro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController:ControllerBase
    {
        private readonly IRestauranteBLL _restauranteBll;
        private ILoggerManager _logger;

        private IMapper _mapper;
        
        public RestauranteController(IRestauranteBLL restauranteBLL, ILoggerManager logger, IMapper mapper)
        {
            _restauranteBll = restauranteBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<RestauranteDTO>> Get()
        {
            var model = _restauranteBll.GetAll();
            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Restaurante não encontrados."));
            }

            List<RestauranteDTO> listaRestaurantes = new List<RestauranteDTO>();

            foreach (var item in model)
            {
                listaRestaurantes.Add(_mapper.Map<RestauranteDTO>(item));
            }

            return Ok(new ApiOkResponse(listaRestaurantes));
        }

        [HttpGet("{id}")]
        public ActionResult<RestauranteDTO> Get(int id)
        {
            var model = _restauranteBll.GetRestaurante(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"Restaurante com o Id->{id} não foi encontrado."));
            }

            return Ok(new ApiOkResponse(_mapper.Map<RestauranteDTO>(model)));
        }

        [HttpPost]
        public IActionResult Create([FromBody]RestauranteDTO restaurante)
        {
            _restauranteBll.Inserir(_mapper.Map<Restaurante>(restaurante));

            return Ok(new ApiResponse(200, "Inserido com sucesso."));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _restauranteBll.Remove(id);

            return Ok(new ApiResponse(200, $"Restaurante com o Id->{id} removido com sucesso."));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] RestauranteDTO restaurante)
        {
            _restauranteBll.Update(_mapper.Map<Restaurante>(restaurante));

            return Ok(new ApiResponse(200, $"Restaurante com o Id->{id} atualizado com sucesso."));
        }
    }
}