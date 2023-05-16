using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities;

public class InterviewTypeLookUp
{
    [MaxLength(50)]
    public string InterviewTypeCode { get; set; }
    
    [MaxLength(256)]
    public string InterviewTypeDescription { get; set; }
}