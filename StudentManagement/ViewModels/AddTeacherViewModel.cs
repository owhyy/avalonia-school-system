using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class AddTeacherViewModel : ViewModelBase
{
    private string _firstName;
    private string _lastName;
    private TeachingSubject _subject;

    public AddTeacherViewModel()
    {
        var canAddTeacher = this.WhenAnyValue(
            teacher => teacher.FirstName,
            teacher => teacher.LastName,
            teacher => teacher.Subject,
            (firstName, lastName, subject) =>
                !string.IsNullOrEmpty(firstName)
                && !string.IsNullOrEmpty(lastName)
                && subject != null
        );

        AddTeacher = ReactiveCommand.Create(
            () =>
                new Teacher
                {
                    FirstName = FirstName,
                    LastName = LastName,
                    Subject = Subject
                },
            canAddTeacher
        );
    }

    public IEnumerable<TeachingSubject> Subjects =>
        Enum.GetValues(typeof(TeachingSubject)).Cast<TeachingSubject>();

    [EnumDataType(typeof(TeachingSubject))]
    public TeachingSubject Subject
    {
        get => _subject;
        set => this.RaiseAndSetIfChanged(ref _subject, value);
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

    public ReactiveCommand<Unit, Teacher> AddTeacher { get; }
}