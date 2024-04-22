namespace OnlineCourse.Model.Models;

public class GetAllListMainResponseModel
{
    public int index { get; set; }
    public int size { get; set; }
    public int count { get; set; }
    public int pages { get; set; }
    public bool hasPrevious { get; set; }
    public bool hasNext { get; set; }
    public object items { get; set; }
}
