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

        [HttpGet("GetAll")]
        public ActionResult<List<PratoDTO>> GetAll()
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

            /*List<PratoDTO> listaT = new List<PratoDTO>();
            PratoDTO prat = new PratoDTO
            {
                IdPrato = 1,
                NomePrato = "ricota",
                PrecoPrato = 20,
                IdRestaurante = 1
            };
            listaT.Add(prat);
            return listaT;*/

            return Ok(new ApiOkResponse(listaPratos));
        }

        [HttpGet("GetId/{id}")]
        public ActionResult<PratoDTO> GetId(int id)
        {
            var model = _pratoBll.GetPrato(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"Prato com o Id->{id} não foi encontrado."));
            }

            return Ok(new ApiOkResponse(_mapper.Map<PratoDTO>(model)));
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]PratoDTO Prato)
        {
            _pratoBll.Inserir(_mapper.Map<Prato>(Prato));

            return Ok(new ApiResponse(200, "Inserido com sucesso."));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _pratoBll.Remove(id);

            return Ok(new ApiResponse(200, $"Prato com o Id->{id} removido com sucesso."));
        }

        [HttpPut("Update/{id}")]
        public IActionResult Update(int id, [FromBody] PratoDTO Prato)
        {
            _pratoBll.Update(_mapper.Map<Prato>(Prato));

            return Ok(new ApiResponse(200, $"Prato com o Id->{id} atualizado com sucesso."));
        }
    }
}