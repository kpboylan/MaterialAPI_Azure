using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DTO;
using Model;
using Repository;
using Persistence;

namespace Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly ERPContext _context;

        public MaterialRepository(ERPContext context)
        {
            _context = context;
        }


        public async Task<List<GetMaterialResponse>> GetActiveMaterialsNewAsync()
        {
            try
            {
                return await (from material in _context.Materials.Where(p => p.Active)
                              //where material.Active 
                              join uom in _context.UOM on material.UOMId equals uom.UOMID
                              join materialType in _context.MaterialTypes on material.MaterialType equals materialType.MaterialTypeID
                              select new GetMaterialResponse
                              {
                                  MaterialID = material.MaterialID,
                                  MaterialType = material.MaterialType,
                                  UOMId = material.UOMId,
                                  MaterialName = material.MaterialName,
                                  Description = material.Description,
                                  CurrentStock = material.CurrentStock,
                                  UOMCode = uom.UOMCode,
                                  MaterialTypeAbbreviation = materialType.MaterialTypeAbbreviation,
                                  Active = material.Active
                              })
                              .ToListAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("A database error occurred.", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<MaterialType>> GetMaterialTypesAsync()
        {
            try
            {
                return await _context.MaterialTypes.ToListAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("A database error occurred.", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<UOM>> GetUOMAsync()
        {
            try
            {
                return await _context.UOM.ToListAsync();
            }
            catch (SqlException ex)
            {
                throw new Exception("A database error occurred.", ex);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
