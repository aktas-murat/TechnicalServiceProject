namespace TechnicalService.Core.ViewModels
{
    public class ServiceViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public int CustomerId { get; set; }

        public string Address { get; set; }
        public string BuildingNo { get; set; }
        public string FloorNo { get; set; }
        public string DoorNo { get; set; }

        public int TechnicianId { get; set; }

        public int CartId { get; set; }

        public int ServiceStatusId { get; set; }

        public string Message { get; set; }
    }
}
