namespace EFQuerySample.Entities;

public class Comment
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
    public string CommentBy { get; set; }
    public string  CommentText { get; set; }
    public string StarCount { get; set; }
    public bool IsApproved { get; set; }
}