using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class EmployeeStatusLookUp
{
    [MaxLength(64)]
    public string EmployeeStatusCode { get; set; }
    
    [MaxLength(1024)]
    public string EmployeeStatusDescription { get; set; }
}