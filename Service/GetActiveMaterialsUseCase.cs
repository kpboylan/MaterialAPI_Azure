using AutoMapper;
using DTO;
using Repository;


namespace Service
{
    public class GetActiveMaterialsUseCase
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly IMapper _mapper;

        public GetActiveMaterialsUseCase(IMaterialRepository materialRepository, IMapper mapper)
        {
            _materialRepository = materialRepository;
            _mapper = mapper;
        }

        public async Task<List<GetMaterialResponse>> Execute()
        {
            try
            {
                var materials = await _materialRepository.GetActiveMaterialsNewAsync();

                return _mapper.Map<List<GetMaterialResponse>>(materials);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while processing your request.", ex);
            }
        }
    }
}
