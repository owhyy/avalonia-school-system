using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public enum Gender
{
    Male,
    Female
}

public enum Grade
{
    Freshman,
    Sophomore,
    Junior,
    Senior
}

public class Student
{
    public int studentId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters"
    )]
    [DataType(DataType.Text)]
    public string firstName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters"
    )]
    [DataType(DataType.Text)]
    public string lastName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    public DateTime birthDate { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [EnumDataType(typeof(Gender))]
    public Gender gender { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [EnumDataType(typeof(Grade))]
    public Grade grade { get; set; }
}
