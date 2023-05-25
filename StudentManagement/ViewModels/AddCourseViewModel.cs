using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class CourseCodeValidationAttribute : ValidationAttribute
{
    public CourseCodeValidationAttribute()
    {
        ErrorMessage = "Code must be between 4 and 10 characters";
    }

    public override bool IsValid(object? value)
    {
        return ValidationUtils.IsValidCourseCode(value);
    }
}

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class HoursValidationAttribute : ValidationAttribute
{
    public HoursValidationAttribute()
    {
        ErrorMessage = "Total hours have to be > 0";
    }

    public override bool IsValid(object? value)
    {
        return ValidationUtils.IsGreaterThanZero(value);
    }
}

public class AddCourseViewModel : ViewModelBase
{
    public AddCourseViewModel(Database db)
    {
        _database = db;
        var canAddCourse = this.WhenAnyValue(
            course => course.Code,
            course => course.Title,
            course => course.Hours,
            course => course.Teacher,
            course => course.Group,
            (code, title, hours, teacher, group) =>
                ValidationUtils.IsValidGroupCode(code)
                && !string.IsNullOrEmpty(title)
                && ValidationUtils.IsGreaterThanZero(hours)
                && teacher != null
                && group != null
        );

        AddCourse = ReactiveCommand.Create(
            () =>
                new Course
                {
                    CourseCode = Code,
                    Title = Title,
                    TotalHours = Hours,
                    Teacher = Teacher,
                    Group = Group
                }
        );
    }

    private string _code;
    private string _title;
    private int _hours;
    private Teacher _teacher;
    private Group _group;

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        10,
        MinimumLength = 4,
        ErrorMessage = "Course code must be between 4 and 10 characers"
    )]
    [DataType(DataType.Text)]
    public string Code
    {
        get => _code;
        set => this.RaiseAndSetIfChanged(ref _code, value);
    }

    [Required(ErrorMessage = "{0} is required")]
    [StringLength(
        50,
        MinimumLength = 3,
        ErrorMessage = "Title of the course should be at least 3 characters and at most 50 characters long"
    )]
    [DataType(DataType.Text)]
    public string Title
    {
        get => _title;
        set => this.RaiseAndSetIfChanged(ref _title, value);
    }

    [HoursValidation]
    public int Hours
    {
        get => _hours;
        set => this.RaiseAndSetIfChanged(ref _hours, value);
    }

    // TODO: see why it doesn't change here
    // [Required(ErrorMessage = "{0} is required")]
    [EnumDataType(typeof(Teacher))]
    public Teacher Teacher
    {
        get => _teacher;
        set => this.RaiseAndSetIfChanged(ref _teacher, value);
    }

    // TODO: here too
    // [Required(ErrorMessage = "{0} is required")]
    [EnumDataType(typeof(Group))]
    public Group Group
    {
        get => _group;
        set => this.RaiseAndSetIfChanged(ref _group, value);
    }

    private Database _database;
    public IEnumerable<Group> Groups => _database.Groups;
    public IEnumerable<Teacher> Teachers => _database.Teachers;
    public ReactiveCommand<Unit, Course> AddCourse { get; }
}
