using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public enum TeachingSubject
{
    Arts,
    Humanities,
    Science,
    Mathematics
}

public class Teacher
{
    public int TeacherId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "First Name should be minimum 3 characters and a maximum of 50 characters"
    )]
    [DataType(DataType.Text)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters"
    )]
    [DataType(DataType.Text)]
    public string LastName { get; set; }

    public TeachingSubject Subject { get; set; }

    public override string ToString()
    {
        return $"{FirstName} {LastName}";
    }
}
