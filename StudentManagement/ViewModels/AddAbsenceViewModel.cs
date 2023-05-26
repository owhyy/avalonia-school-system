using System;
using System.Collections.Generic;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

public class AddAbsenceViewModel : ViewModelBase
{
    private Student _student;
    private Course _course;
    private DateOnly _date = DateOnly.FromDateTime(DateTime.Today);

    public AddAbsenceViewModel(Database db)
    {
        _database = db;

        var canAddAbsence = this.WhenAnyValue(
            absence => absence.Student,
            absence => absence.Course,
            absence => absence.Date,
            (student, course, date) =>
                student != null && course != null && date != DateOnly.MinValue
        );

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

    private Database _database;

    public IEnumerable<Student> Students => _database.Students;
    public IEnumerable<Course> Courses => _database.Courses;

    public ReactiveCommand<Unit, Absence> AddAbsence { get; }
}