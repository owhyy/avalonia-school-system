using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using StudentManagement.Services;

namespace StudentManagement.Models;

public enum Gender
{
    Male,
    Female
}

public class Student
{
    public int StudentId { get; set; }

    [Required]
    [StringLength(
        20,
        MinimumLength = 3,
        ErrorMessage = "First Name should be between 3 characters and 20 characters"
    )]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(
        20,
        MinimumLength = 3,
        ErrorMessage = "Last Name should be between 3 characters and 20 characters"
    )]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [Required]
    [EnumDataType(typeof(Group))]
    public Group Group { get; set; }

    public double AverageGrade(Student s) =>
        new Database().Marks.Where(g => g.Student == s).Average(g => g.Value);
}
