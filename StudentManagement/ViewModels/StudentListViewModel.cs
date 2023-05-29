using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

public class ExtendedStudent : Student
{
    public ExtendedStudent(Student s)
    {
        StudentId = s.StudentId;
        FirstName = s.FirstName;
        LastName = s.LastName;
        BirthDate = s.BirthDate;
        Gender = s.Gender;
        Group = s.Group;
    }

    public string AverageMark { get; set; }
    public int AbsenceCount { get; set; }
}

public class StudentListViewModel : ViewModelBase
{
    private Group _group;
    private string _subject;
    private bool _dialogIsOpen;
    private IEnumerable<ExtendedStudent> _students;

    public StudentListViewModel(Database db)
    {
        ExtendedStudent createExtendedStudent(Student student)
        {
            var extendedStudent = new ExtendedStudent(student);
                    try
                    {
                        extendedStudent.AverageMark = db.Marks.Where(g => g.Student == student).Average(g => g.Value).ToString("#.##");
                    }
                    catch (Exception e)
                    {
                        extendedStudent.AverageMark = "no marks";
                    }

                    try
                    {
                        extendedStudent.AbsenceCount = db.Absences.Count(g => g.Student == student);
                    }
                    catch (Exception)
                    {
                        extendedStudent.AbsenceCount = 0;
                    }

                    return extendedStudent;
        } 
    
        
        var students = db.Students.Include(s => s.Group);
        var extendedStudents = new List<ExtendedStudent>();

        foreach (var student in students)
        {
            var extendedStudent = createExtendedStudent(student);
            extendedStudents.Add(extendedStudent);
        }

        Students = new ObservableCollection<ExtendedStudent>(extendedStudents);
        GoBack = ReactiveCommand.Create(() => { });
        DeleteStudentsWithAverageLessThan7 = ReactiveCommand.Create(() =>
        {
        });
        ShowFilterByGroupDialog = ReactiveCommand.Create(() =>
        {
            Groups = new ObservableCollection<Group>(db.Groups);
            DialogIsOpen = !DialogIsOpen;
        });
        FilterByGroup = ReactiveCommand.Create(() =>
        {
            var filteredStudents = extendedStudents.Where(s => s.Group == GroupToFilterBy);
            Students = new ObservableCollection<ExtendedStudent>(filteredStudents);
            DialogIsOpen = !DialogIsOpen;
        });
    }

    public ObservableCollection<ExtendedStudent> Students { get => new(_students); set => this.RaiseAndSetIfChanged(ref _students, value); }
    public ReactiveCommand<Unit, Unit> GoBack { get; }

    public bool DialogIsOpen
    {
        get => _dialogIsOpen;
        set => this.RaiseAndSetIfChanged(ref _dialogIsOpen, value);
    }

    public Group GroupToFilterBy
    {
        get => _group;
        set => this.RaiseAndSetIfChanged(ref _group, value);
    }

    public ObservableCollection<Group> Groups { get; set; }

    public ReactiveCommand<Unit, Unit> DeleteStudentsWithAverageLessThan7 { get; }
    public ReactiveCommand<Unit, Unit> FilterByGroup { get; }
    public ReactiveCommand<Unit, Unit> ShowFilterByGroupDialog { get; }
}