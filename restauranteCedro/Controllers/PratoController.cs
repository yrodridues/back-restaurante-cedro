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
    public class PratoController: ControllerBase
    {
        private readonly IPratoBLL _pratoBll;
        private ILoggerManager _logger;

        private IMapper _mapper;
        
        public PratoController(IPratoBLL pratoBLL, ILoggerManager logger, IMapper mapper)
        {
            _pratoBll = pratoBLL;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<PratoDTO>> Get()
        {
            var model = _pratoBll.GetAll();
            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Prato não encontrados."));
            }

            List<PratoDTO> listaPratos = new List<PratoDTO>();

            foreach (var item in model)
            {
                listaPratos.Add(_mapper.Map<PratoDTO>(item));
            }

            return Ok(new ApiOkResponse(listaPratos));
        }

        [HttpGet("{id}")]
        public ActionResult<PratoDTO> Get(int id)
        {
            var model = _pratoBll.GetPrato(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"Prato com o Id->{id} não foi encontrado."));
            }

            return Ok(new ApiOkResponse(_mapper.Map<PratoDTO>(model)));
        }

        [HttpPost]
        public IActionResult Create([FromBody]PratoDTO Prato)
        {
            _pratoBll.Inserir(_mapper.Map<Prato>(Prato));

            return Ok(new ApiResponse(200, "Inserido com sucesso."));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _pratoBll.Remove(id);

            return Ok(new ApiResponse(200, $"Prato com o Id->{id} removido com sucesso."));
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] PratoDTO Prato)
        {
            _pratoBll.Update(_mapper.Map<Prato>(Prato));

            return Ok(new ApiResponse(200, $"Prato com o Id->{id} atualizado com sucesso."));
        }
    }
}