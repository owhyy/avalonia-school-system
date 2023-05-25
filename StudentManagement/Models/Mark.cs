using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Models;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class IntBetween1And10Validation : ValidationAttribute
{
    public IntBetween1And10Validation()
    {
        ErrorMessage = "Value must be between 1 and 10";
    }

    public override bool IsValid(object? value)
    {
        if (value is not int i)
            return false;
        return i is >= 1 and <= 10;
    }
}

public class Mark
{
    [Key]
    public int MarkId { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Student Student { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    public Course Course { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [IntBetween1And10Validation]
    public int Value { get; set; }

    [Required(ErrorMessage = "{0} is required")]
    [DataType(DataType.Date)]
    public DateOnly DateReceived { get; set; }
}
