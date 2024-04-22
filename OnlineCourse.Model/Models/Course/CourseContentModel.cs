using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnlineCourse.Model.Models;

public class CourseContentModel
{
    public int SortNumber { get; set; }
    public string Summary { get; set; }
    public Guid CourseId { get; set; }

    [JsonIgnore]
    public virtual CourseModel Course { get; set; }
    public virtual ICollection<CourseDocumentModel> CourseDocuments { get; set; }
}
