using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourse.Model.Enums;

public enum CourseStatus
{
    WaitingForApproval = 0,
    Active = 1,
    Draft = 2,
    IsExamined = 3,
    Denied = 4,
    Prohibited = 5
}

