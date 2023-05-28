using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;
using Z.BulkOperations.Internal;

namespace StudentManagement.ViewModels;

public class AddAbsenceViewModel : ViewModelBase
{
    private Course _course;

    private DateOnly _date = DateOnly.FromDateTime(DateTime.Today);
    private Student _student;
    private IEnumerable<Student> _students;
    private IEnumerable<Course> _courses;

    public AddAbsenceViewModel(Database db)
    {
        var canAddAbsence = this.WhenAnyValue(
            absence => absence.Student,
            absence => absence.Course,
            absence => absence.Date,
            (student, course, date) =>
                student != null && course != null && date != DateOnly.MinValue
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

        AddAbsence = ReactiveCommand.Create(
            () =>
                new Absence
                {
                    Student = Student,
                    Course = Course,
                    Date = Date
                },
            canAddAbsence
        );
    }

    public Student Student
    {
        get => _student;
        set => this.RaiseAndSetIfChanged(ref _student, value);
    }

    public Course Course
    {
        get => _course;
        set => this.RaiseAndSetIfChanged(ref _course, value);
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


    public ReactiveCommand<Unit, Absence> AddAbsence { get; }
}