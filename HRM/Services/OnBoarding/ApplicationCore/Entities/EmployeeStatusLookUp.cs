using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class EmployeeStatusLookUp
{
    public int Id { get; set; }
    [MaxLength(64)]
    public string EmployeeStatusCode { get; set; }
    
    [MaxLength(1024)]
    public string EmployeeStatusDescription { get; set; }
}