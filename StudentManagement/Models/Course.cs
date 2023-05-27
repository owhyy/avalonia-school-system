using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace StudentManagement.Models;

public sealed class Course
{

    public override string ToString()
    {
        return $"{Title}({CourseCode})";
    }

    public string CourseId { get; set; }
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
}
