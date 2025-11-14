namespace GrandHayath.HotelBooking.Domain.Entity 
{ 
    public class Employee
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string FullName { get; set; }
        public string Role {  get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }

        public Hotel Hotel { get; set; }

    }
}
