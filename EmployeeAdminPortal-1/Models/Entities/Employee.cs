namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; } //Guid = Globally unique Identifier

        public required string Name { get; set; } // required = not a nullable property

        public required string Email { get; set; }

        public string? Phone { get; set; } // ? = can be a nullable property

        public decimal Salary {  get; set; }
    }
}
