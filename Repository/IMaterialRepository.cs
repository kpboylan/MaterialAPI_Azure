

using DTO;
using Model;

namespace Repository
{
    public interface IMaterialRepository
    {
        Task<List<GetMaterialResponse>> GetActiveMaterialsNewAsync();
        Task<List<MaterialType>> GetMaterialTypesAsync();
        Task<List<UOM>> GetUOMAsync();
    }
}