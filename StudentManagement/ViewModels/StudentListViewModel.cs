using System;
using System.Collections;
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
    public double AverageMark { get; set; }
    public int AbsenceCount { get; set; }

    public ExtendedStudent(Student s)
    {
        StudentId = s.StudentId;
        FirstName = s.FirstName;
        LastName = s.LastName;
        Gender = s.Gender;
        Group = s.Group;
    }
}

public class StudentListViewModel : ViewModelBase
{
    public StudentListViewModel(Database db)
    {
        var students = db.Students.Include(s => s.Group);
        var extendedStudents = new List<ExtendedStudent>();
        foreach (var student in students)
        {
            var extendedStudent = new ExtendedStudent(student);
            {
                try
                {
                    extendedStudent.AverageMark = db.Marks.Where(g => g.Student == student).Average(g => g.Value);
                }
                catch (Exception e)
                {
                    extendedStudent.AverageMark = 0;
                }

                try
                {
                    extendedStudent.AbsenceCount = db.Absences.Count(g => g.Student == student);
                }
                catch (Exception)
                {
                    extendedStudent.AbsenceCount = 0;
                }
            }
            extendedStudents.Add(extendedStudent);
        }

        Students = new ObservableCollection<ExtendedStudent>(extendedStudents);
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<ExtendedStudent> Students { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}