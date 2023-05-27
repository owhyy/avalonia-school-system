using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public sealed class GroupCodeValidationAttribute : ValidationAttribute
{
    public GroupCodeValidationAttribute()
    {
        ErrorMessage = "{0} doesn't follow the pattern x-dddd";
    }

    public override bool IsValid(object? value)
    {
        return ValidationUtils.IsValidGroupCode(value);
    }
}

public class AddGroupViewModel : ViewModelBase
{
    private string _code;
    private Grade _grade;

    public AddGroupViewModel()
    {
        var canAddGroup = this.WhenAnyValue(group => group.Code, ValidationUtils.IsValidGroupCode);
        AddGroup = ReactiveCommand.Create(
            () => new Group { Grade = Grade, GroupCode = Code },
            canAddGroup
        );
    }

    public IEnumerable<Grade> Grades => Enum.GetValues(typeof(Grade)).Cast<Grade>();

    [Required]
    [GroupCodeValidation]
    public string Code
    {
        get => _code;
        set => this.RaiseAndSetIfChanged(ref _code, value);
    }

    [EnumDataType(typeof(Grade))]
    public Grade Grade
    {
        get => _grade;
        set => this.RaiseAndSetIfChanged(ref _grade, value);
    }

    public ReactiveCommand<Unit, Group> AddGroup { get; }
}