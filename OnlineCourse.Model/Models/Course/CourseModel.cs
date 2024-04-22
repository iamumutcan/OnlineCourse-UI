using OnlineCourse.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineCourse.Model.Models;

public class CourseModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int SortNumber { get; set; }
    public CourseStatus Status { get; set; }
    public Guid CategoryId { get; set; }

    [JsonIgnore]
    public virtual CategoryModel Category { get; set; }
    public virtual ICollection<CourseContentModel> CourseContents { get; set; }
}
