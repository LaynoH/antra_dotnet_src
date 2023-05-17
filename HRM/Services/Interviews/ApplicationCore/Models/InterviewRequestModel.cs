using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Models;

public class InterviewRequestModel
{
    [Required(ErrorMessage = "Please enter interview id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter begin time")]
    public DateTime BeginTime { get; set; }
    
    [Required(ErrorMessage = "Please enter candidate's email")]
    public string CandidateEmail { get; set; }
    
    [MaxLength(50)]
    [Required(ErrorMessage = "Please enter candidate's first name")]
    public string CandidateFirstName { get; set; }
    
    [Required(ErrorMessage = "Please enter candidate's identity id")]
    public Guid CandidateIdentityId { get; set; }

    [MaxLength(50)]
    [Required(ErrorMessage = "Please enter candidate's last name")]
    public string CandidateLastName { get; set; }
    
    [Required(ErrorMessage = "Please enter end time")]
    public DateTime EndTime { get; set; }
    
    [Required(ErrorMessage = "Please enter feedback")]
    public string Feedback { get; set; }
    
    [Required(ErrorMessage = "Please enter interviewer's id")]
    public int InterviewerId { get; set; }
    
    [Required(ErrorMessage = "Please enter interview's type id")]
    public int InterviewTypeId { get; set; }
    
    public bool? Passed { get; set; }
    public int? Rating { get; set; }
    
    [Required(ErrorMessage = "Please enter submission id")]
    public int SubmissionId { get; set; }
}