using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public sealed class Course
{
    public int CourseId { get; set; }
    public string CourseCode { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "Title of the course should be minimum 3 characters and a maximum of 50 characters"
    )]
    [DataType(DataType.Text)]
    public string Title { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Teacher Teacher { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int TotalHours { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Group Group { get; set; }

    public override string ToString()
    {
        return $"{Title}({Group})";
    }
}