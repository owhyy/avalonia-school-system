using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models;

public class Mark
{
    [Key] public int MarkId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Student Student { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Course Course { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public int Value { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    public DateOnly DateReceived { get; set; }
}