namespace OnlineCourse.Model.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<CourseModel> Courses { get; set; }

}