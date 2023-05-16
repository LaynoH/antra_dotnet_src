using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class Interviewer
{
    public int Id { get; set; }
    public string Email { get; set; }
    public Guid EmployeeIdentityId { get; set; }
    
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }
}