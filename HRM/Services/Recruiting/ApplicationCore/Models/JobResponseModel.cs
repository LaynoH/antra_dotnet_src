using Microsoft.EntityFrameworkCore;

namespace ApplicationCore.Models;

public class JobResponseModel
{
    public int Id { get; set; }
    public string Ttile { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public int NumberOfPositions { get; set; }
}