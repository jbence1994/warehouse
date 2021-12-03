namespace Warehouse.Controllers.Resources.Responses
{
    public class GetTechnicianResponseResource
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public double Balance { get; set; }
    }
}
