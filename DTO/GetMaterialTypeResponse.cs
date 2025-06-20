namespace DTO
{
    public class GetMaterialTypeResponse
    {
        public int MaterialTypeID { get; set; }
        public string MaterialTypeName { get; set; }
        public string MaterialTypeAbbreviation { get; set; }
        public bool IsActive { get; set; }
    }
}
