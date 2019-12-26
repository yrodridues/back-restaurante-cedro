using AutoMapper;
using restauranteCedro.DAL.DTO;
using restauranteCedro.DAL.Models;

namespace restauranteCedro
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            CreateMap<RestauranteDTO, Restaurante>().
                /* ForSourceMember("StoreId", s => s.Ignore()).
                ForSourceMember("UId", s => s.Ignore()).
                ForMember("Id", s => s.Ignore()). */
                AfterMap((dto, model) => model.IdRestaurante = dto.IdRestaurante);

            CreateMap<Restaurante, RestauranteDTO>()
                .AfterMap((model, dto) => dto.IdRestaurante = model.IdRestaurante);

        }
       
    }
}
