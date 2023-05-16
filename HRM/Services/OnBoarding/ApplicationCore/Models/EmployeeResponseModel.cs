namespace ApplicationCore.Models;

public class EmployeeResponseModel
{
    public int Id { get; set; }
    
    public string Address { get; set; }

    public int EmployeeStatusId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string SSN { get; set; }
}