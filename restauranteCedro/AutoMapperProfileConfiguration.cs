using AutoMapper;
using restauranteCedro.DAL.DTO;
using restauranteCedro.DAL.Models;

namespace restauranteCedro
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<RestauranteDTO, Restaurante>()
                .AfterMap((dto, model) => model.IdRestaurante = dto.IdRestaurante);
            CreateMap<Restaurante, RestauranteDTO>()
                .AfterMap((model, dto) => dto.IdRestaurante = model.IdRestaurante);


            CreateMap<PratoDTO, Prato>()
                .AfterMap((dto, model) => model.IdPrato = dto.IdPrato);
            CreateMap<Prato, PratoDTO>()
                .AfterMap((model, dto) => dto.IdPrato = model.IdPrato);
        }
    }
}
