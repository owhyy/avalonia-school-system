using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class IntBetween1And10ValidationAttribute : ValidationAttribute
{
    public IntBetween1And10ValidationAttribute()
    {
        ErrorMessage = "Value must be between 1 and 10";
    }

    public override bool IsValid(object? value)
    {
        return ValidationUtils.IsValidMark(value);
    }
}

public class AddMarkViewModel : ViewModelBase
{
    private Course _course;
    private Student _student;
    private int _value;
    private DateOnly _date = DateOnly.FromDateTime(DateTime.Today);

    public AddMarkViewModel(Database db)
    {
        _database = db;
        var canAddMark = this.WhenAnyValue(
            mark => mark.Student,
            mark => mark.Course,
            mark => mark.Date,
            mark => mark.Value,
            (student, course, date, value) =>
                student != null
                && course != null
                && date != DateOnly.MinValue
                && ValidationUtils.IsValidMark(value)
        );

        AddMark = ReactiveCommand.Create(
            () =>
                new Mark
                {
                    Student = Student,
                    Course = Course,
                    DateReceived = Date,
                    Value = Value
                }
        );
    }

    public ReactiveCommand<Unit, Mark> AddMark { get; }

    public Course Course
    {
        get => _course;
        set => this.RaiseAndSetIfChanged(ref _course, value);
    }

    public Student Student
    {
        get => _student;
        set => this.RaiseAndSetIfChanged(ref _student, value);
    }

    [IntBetween1And10Validation]
    public int Value
    {
        get => _value;
        set => this.RaiseAndSetIfChanged(ref _value, value);
    }

    public DateOnly Date
    {
        get => _date;
        set => this.RaiseAndSetIfChanged(ref _date, value);
    }

    private Database _database;

    public IEnumerable<Student> Students => _database.Students;
    public IEnumerable<Course> Courses => _database.Courses;
}
