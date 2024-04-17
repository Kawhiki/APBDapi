namespace APBDAPI;

public class Visit
{
    public int Id { get; set; }
    public DateTime DateOfVisit { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}