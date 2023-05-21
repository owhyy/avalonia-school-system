using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class AddStudentViewModel : ViewModelBase
{
    private DateTime _birthDate = DateTime.Today;
    private string _firstName;
    private Gender _gender;
    private Grade _grade;
    private string _lastName;

    public AddStudentViewModel()
    {
        var canAddStudent = this.WhenAnyValue(
            student => student.FirstName,
            student => student.LastName,
            (firstName, lastName) =>
                !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName)
        );

        AddStudent = ReactiveCommand.Create(
            () =>
                new Student
                {
                    firstName = FirstName,
                    lastName = LastName,
                    birthDate = BirthDate,
                    grade = Grade,
                    gender = Gender
                },
            canAddStudent
        );
    }

    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    public Gender Gender
    {
        get => _gender;
        set => this.RaiseAndSetIfChanged(ref _gender, value);
    }

    public IEnumerable<Gender> Genders
    {
        get => Enum.GetValues(typeof(Gender)).Cast<Gender>();
    }

    public Grade Grade
    {
        get => _grade;
        set => this.RaiseAndSetIfChanged(ref _grade, value);
    }

    public IEnumerable<Grade> Grades
    {
        get => Enum.GetValues(typeof(Grade)).Cast<Grade>();
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    public DateTime Now => DateTime.Today;

    public ReactiveCommand<Unit, Student> AddStudent { get; }
}
