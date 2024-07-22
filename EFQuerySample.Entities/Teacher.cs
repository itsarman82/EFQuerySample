namespace EFQuerySample.Entities;

public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public ICollection<CourseTeachers> CourseTeachers { get; set; }
}