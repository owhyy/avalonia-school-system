using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

public class AddStudentViewModel : ViewModelBase
{
    // TODO: change this to a DateOnly
    private DateTime _birthDate = DateTime.Today;
    private string _firstName;
    private Gender _gender;
    private string _lastName;
    private Group _group;

    public AddStudentViewModel(Database db)
    {
        _database = db;

        var canAddStudent = this.WhenAnyValue(
            student => student.FirstName,
            student => student.LastName,
            student => student.Group,
            (firstName, lastName, group) =>
                !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && group != null
        );

        AddStudent = ReactiveCommand.Create(
            () =>
                new Student
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    BirthDate = DateOnly.FromDateTime(BirthDate),
                    Gender = Gender,
                    Group = Group
                },
            canAddStudent
        );
    }

    [Required(ErrorMessage = "First name is required")]
    [StringLength(
        20,
        MinimumLength = 3,
        ErrorMessage = "First name should be between 3 characters and 20 characters"
    )]
    [DataType(DataType.Text)]
    public string FirstName
    {
        get => _firstName;
        set => this.RaiseAndSetIfChanged(ref _firstName, value);
    }

    [Required(ErrorMessage = "Last name is required")]
    [StringLength(
        20,
        MinimumLength = 3,
        ErrorMessage = "Last name should be between 3 characters and 20 characters"
    )]
    [DataType(DataType.Text)]
    public string LastName
    {
        get => _lastName;
        set => this.RaiseAndSetIfChanged(ref _lastName, value);
    }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender
    {
        get => _gender;
        set => this.RaiseAndSetIfChanged(ref _gender, value);
    }

    public IEnumerable<Gender> Genders => Enum.GetValues(typeof(Gender)).Cast<Gender>();

    [Required]
    [DataType(DataType.Date)]
    public DateTime BirthDate
    {
        get => _birthDate;
        set => this.RaiseAndSetIfChanged(ref _birthDate, value);
    }

    [Required]
    [EnumDataType(typeof(Group))]
    public Group Group
    {
        get => _group;
        set => this.RaiseAndSetIfChanged(ref _group, value);
    }

    private readonly Database _database;
    public ReactiveCommand<Unit, Student> AddStudent { get; }
    public IEnumerable<Group> Groups => _database.Groups;
}
