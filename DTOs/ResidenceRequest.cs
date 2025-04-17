namespace WebApplication1.DTOs
{
    public class ResidenceRequest
    {
        public int ResidenceId { get; set; }
        public int Num_Of_Rooms { get; set; }
        public string? Street { get; set; }
        public int Building_Num { get; set; }
        public int Apartment_Num { get; set; }
        public int Floor_Num { get; set; }
        public string? Type { get; set; }
        public string? Status { get; set; }
        public double Rent_Fee { get; set; }
        public List<string> PictureUrls { get; set; }
        public int UserId { get; set; }
    }
}
