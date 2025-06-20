using AutoMapper;
using DTO;
using Model;

namespace MapperProfile
{
    public class MaterialProfile : Profile
    {
        public MaterialProfile() 
        {
            CreateMap<GetMaterialTypeResponse, MaterialType>();
            CreateMap<MaterialType, GetMaterialTypeResponse>();

            CreateMap<GetUOMRequest, UOM>();
            CreateMap<UOM, GetUOMRequest>();

            CreateMap<GetMaterialResponse, Material>();
            CreateMap<Material, GetMaterialResponse>();

        }
    }
}
