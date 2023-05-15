using System;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;


public class AddStudentViewModel : ViewModelBase
{
    private string _firstName;
    private string _lastName;
    private DateTime _birthDate;
    private Gender _gender;
    private Grade _grade;


    public AddStudentViewModel()
    {
        var canAddStudent = this.WhenAnyValue(student => student.FirstName, student => student.LastName,
            student => student.Gender, student => student.Grade, (firstName, lastName, gender, grade) =>

                !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !_birthDate.Equals(null) && !grade.Equals(null) &&
                !gender.Equals(null));

        AddStudent = ReactiveCommand.Create(() => new Student {firstName = FirstName, lastName = LastName, birthDate = BirthDate, grade = Grade, gender = Gender}
            ,canAddStudent);
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
    
    public Grade Grade
    {
        get => _grade;
        set => this.RaiseAndSetIfChanged(ref _grade, value);
    }

    public DateTime BirthDate 
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    public ReactiveCommand<Unit, Student> AddStudent { get; }
}