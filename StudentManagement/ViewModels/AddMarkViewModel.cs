using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
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

    private DateOnly _date = DateOnly.FromDateTime(DateTime.Today);
    private Student _student;
    private int _value;
    private IEnumerable<Student> _students;
    private IEnumerable<Course> _courses;

    public AddMarkViewModel(Database db)
    {
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

        this.WhenAnyValue(absence => absence.Course).Subscribe(course =>
        {
            if (Student == null)
            {
                Students = course == null ? db.Students : db.Students.Where(s => s.Group.Courses.Contains(course));
            }
        });


        this.WhenAnyValue(absence => absence.Student).Subscribe(student =>
        {
            if (Course == null)
            {
                Courses = student == null
                    ? db.Courses.Include(c => c.Group)
                    : db.Courses.Include(c => c.Group.Students).Where(c => c.Group.Students.Contains(student));
            }
        });

        AddMark = ReactiveCommand.Create(
            () =>
                new Mark
                {
                    Student = Student,
                    Course = Course,
                    DateReceived = Date,
                    Value = Value
                },
            canAddMark
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

    public IEnumerable<Student> Students
    {
        get => _students;
        set => this.RaiseAndSetIfChanged(ref _students, value);
    }
    
    public IEnumerable<Course> Courses { 
        get => _courses;
        set => this.RaiseAndSetIfChanged(ref _courses, value);
    }
}