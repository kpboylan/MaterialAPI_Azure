namespace DTO
{
    public class GetUOMRequest
    {
        public int UOMID { get; set; }
        public string UOMCode { get; set; }
        public string UOMDescription { get; set; }
        public string UOMType { get; set; }
        public bool IsActive { get; set; }
    }
}
