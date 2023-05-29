using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using ReactiveUI;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    private readonly Database _db;

    public MainWindowViewModel(Database db)
    {
        _db = db;
        MainMenu = new MenuViewModel();
        GoToLoginView();
    }

    public MenuViewModel MainMenu { get; set; }
    public CourseListViewModel CourseList { get; }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void GoToLoginView()
    {
        var vm = new LoginViewModel(_db.Users);
        vm.Login.Subscribe(validCredentials =>
        {
            if (validCredentials) Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToAddGroupView()
    {
        var vm = new AddGroupViewModel();
        vm.AddGroup.Subscribe(group =>
        {
            if (group == null) return;
            _db.Groups.Add(group);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToAddStudentView()
    {
        var vm = new AddStudentViewModel(_db);
        vm.AddStudent.Subscribe(student =>
        {
            if (student == null)
                return;
            _db.Students.Add(student);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToStudentListView()
    {
        var vm = new StudentListViewModel(_db);
        vm.GoBack.Subscribe(_ => { Content = MainMenu; });
        vm.ShowFilterByGroupDialog.Subscribe(group => { });
        Content = vm;
    }

    public void GoToAddCourseView()
    {
        var vm = new AddCourseViewModel(_db);
        vm.AddCourse.Subscribe(courses =>
        {
            _db.BulkInsert(courses);
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToCourseListView()
    {
        var courses = _db.Courses;
        var vm = new CourseListViewModel(courses.Include(c => c.Teacher).Include(c => c.Group));
        vm.GoBack.Subscribe(_ => { Content = MainMenu; });
        Content = vm;
    }

    public void GoToAddTeacherView()
    {
        var vm = new AddTeacherViewModel();
        vm.AddTeacher.Subscribe(teacher =>
        {
            if (teacher == null) return;
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToAddAbsenceView()
    {
        var vm = new AddAbsenceViewModel(_db);
        vm.AddAbsence.Subscribe(absence =>
        {
            if (absence == null) return;
            _db.Absences.Add(absence);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToAddMarkView()
    {
        var vm = new AddMarkViewModel(_db);
        vm.AddMark.Subscribe(mark =>
        {
            if (mark == null) return;
            _db.Marks.Add(mark);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToMarkListView()
    {
        var vm = new MarkListViewModel(_db.Marks.Include(m => m.Student).Include(m => m.Course.Group));
        vm.GoBack.Subscribe(_ => { Content = MainMenu; });
        Content = vm;
    }

    public void GoToAbsenceListView()
    {
        var vm = new AbsenceListViewModel(_db.Absences.Include(m => m.Student).Include(m => m.Course.Group));
        vm.GoBack.Subscribe(_ => { Content = MainMenu; });
        Content = vm;
    }

    public void Export()
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        var path = Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Students.xlsx");
        
        using (var package = new ExcelPackage(new FileInfo(path)))
        {
            var studentSheet = package.Workbook.Worksheets.Add("Students");
            studentSheet.Cells["A1:F1"].Style.Font.Size = 18f;
            studentSheet.Cells["A1:F1"].Style.Font.Bold = true;
            studentSheet.Cells["A1"].Value = "Id";
            studentSheet.Cells["B1"].Value = "First Name";
            studentSheet.Cells["C1"].Value = "Last Name";
            studentSheet.Cells["D1"].Value = "Birth Date";
            studentSheet.Cells["E1"].Value = "Gender";
            studentSheet.Cells["F1"].Value = "Group";

            var students = new List<Student>(_db.Students.Include(s=>s.Group));
            for (var i = 2; i < students.Count; i++)
            {
                var student = students[i - 2];
                studentSheet.Cells[$"A{i}"].Value = student.StudentId;
                studentSheet.Cells[$"B{i}"].Value = student.FirstName;
                studentSheet.Cells[$"C{i}"].Value = student.LastName;
                studentSheet.Cells[$"D{i}"].Value = student.BirthDate;
                studentSheet.Cells[$"E{i}"].Value = student.Gender.ToString();
                studentSheet.Cells[$"F{i}"].Value = student.Group.ToString();
                }

            var courseSheet = package.Workbook.Worksheets.Add("Courses");
            courseSheet.Cells["A1:F1"].Merge = true;
            courseSheet.Cells["A1:F1"].Style.Font.Size = 18f;
            courseSheet.Cells["A1:F1"].Style.Font.Bold = true;
            courseSheet.Cells["A1"].Value = "Id";
            courseSheet.Cells["B1"].Value = "Code";
            courseSheet.Cells["C1"].Value = "Teacher";
            courseSheet.Cells["D1"].Value = "Title";
            courseSheet.Cells["E1"].Value = "Group";
            courseSheet.Cells["F1"].Value = "Total hours";
            
            var courses = new List<Course>(_db.Courses.Include(c=>c.Teacher).Include(c=>c.Group));
            for (var i = 2; i < courses.Count; i++)
            {
                var course = courses[i - 2];
                courseSheet.Cells[$"A{i}"].Value = course.CourseId;
                courseSheet.Cells[$"B{i}"].Value = course.CourseCode;
                courseSheet.Cells[$"C{i}"].Value = course.Teacher.FirstName;
                courseSheet.Cells[$"D{i}"].Value = course.Title;
                courseSheet.Cells[$"E{i}"].Value = course.Group.GroupCode;
                courseSheet.Cells[$"F{i}"].Value = course.TotalHours;
            }
            
            package.Save();
        }
    }
}