using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class JobRequestModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter Title of the Job")]
    [StringLength(256)]
    public string Ttile { get; set; }
    
    [Required(ErrorMessage = "Please enter Job description")]
    [StringLength(5000)]
    public string Description { get; set; }
    
    [Required(ErrorMessage = "Please enter Job Start Date")]
    [DataType(DataType.Date )]
    public DateTime StartDate { get; set; }
    
    [Required(ErrorMessage = "Please enter number")]
    public int NumberOfPositions { get; set; }
}