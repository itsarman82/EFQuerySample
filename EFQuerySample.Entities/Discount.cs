namespace EFQuerySample.Entities;

public class Discount
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string Name { get; set; }
    public int NewPrice { get; set; }
}