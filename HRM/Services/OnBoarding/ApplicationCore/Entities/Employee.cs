using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Employee
{
    public int Id { get; set; }
    public string Address { get; set; }
    
    [MaxLength(2048)]
    public string? Email { get; set; }
    public Guid EmployeeIdentityId { get; set; }
    public int EmployeeStatusId { get; set; }
    public DateTime? EndDate { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }

    public DateTime? HireDate { get; set; }
    
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [MaxLength(50)]
    public string? MiddleName { get; set; }
    
    [MaxLength(2048)]
    public string SSN { get; set; }
}