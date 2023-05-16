using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class EmployeeRequestModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter Address of the Employee")]
    public string Address { get; set; }
    
    [Required(ErrorMessage = "Please enter Address of the Employee Status Id")]
    public int EmployeeStatusId { get; set; }

    [Required(ErrorMessage = "Please enter Address of the Employee's First Name")]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter Address of the Employee's Last Name")]
    [MaxLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter Address of the Employee's SSN")]
    [MaxLength(2048)]
    public string SSN { get; set; }
}