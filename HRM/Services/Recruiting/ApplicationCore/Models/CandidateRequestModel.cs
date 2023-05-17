using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;

namespace ApplicationCore.Models;

public class CandidateRequestModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter candidate's first name")]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [MaxLength(50)]
    public string? MiddleName { get; set; }
    
    [Required(ErrorMessage = "Please enter candidate's last name")]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "Please enter candidate's email")]
    [MaxLength(512)]
    public string Email { get; set; }
    
    [MaxLength(2048)]
    public string? ResumeURL { get; set; }
    
    [Required(ErrorMessage = "Please enter candidate's create date")]
    public DateTime CreatedOn { get; set; }
    
    //[Required(ErrorMessage = "Please enter submission")]
    //public List<Submission> Submissions { get; set; }
    
    //public Guid CandidateIdentityId { get; set; }
}