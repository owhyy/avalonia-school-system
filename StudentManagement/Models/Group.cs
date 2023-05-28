using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public enum Grade
{
    Freshman,
    Sophomore,
    Junior,
    Senior
}

public class Group
{
    [Key] public string GroupCode { get; set; }

    public Grade Grade { get; set; }
    public virtual ICollection<Course> Courses { get; set; }
    public virtual ICollection<Student> Students { get; }

    public Group()
    {
        Students = new HashSet<Student>();
    }

    public override string ToString()
    {
        return GroupCode;
    }
}