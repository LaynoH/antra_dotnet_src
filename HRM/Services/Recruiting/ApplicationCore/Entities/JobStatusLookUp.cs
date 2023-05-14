namespace ApplicationCore.Entities;

public class JobStatusLookUp
{
    // open, pending, closed, postponded
    public int Id { get; set; }
    public string JobStatusCode { get; set; }
    public string JobStatusDescription { get; set; }
}