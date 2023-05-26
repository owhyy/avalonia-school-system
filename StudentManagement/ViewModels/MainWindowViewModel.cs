using System;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using StudentManagement.Services;

namespace StudentManagement.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private ViewModelBase _content;
    private Database _db;

    public MainWindowViewModel(Database db)
    {
        _db = db;
        MainMenu = new MenuViewModel();
        // GoToLoginView();
        // GoToAddStudentView();
        // GoToAddGroupView();

        // GoToAddCourseView();
        // GoToAddTeacherView();
        // GoToAddAbsenceView();
        // GoToAddMarkView();
        // GoToCourseListView();
        GoToStudentListView();
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
            if (validCredentials)
            {
                Content = MainMenu;
            }
        });
        Content = vm;
    }

    public void GoToAddGroupView()
    {
        var vm = new AddGroupViewModel();
        vm.AddGroup.Subscribe(group =>
        {
            if (group != null)
            {
                _db.Groups.Add(group);
                _db.SaveChanges();
                Content = MainMenu;
            }
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
        vm.GoBack.Subscribe(_ =>
        {
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToAddCourseView()
    {
        var vm = new AddCourseViewModel(_db);
        vm.AddCourse.Subscribe(course =>
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToCourseListView()
    {
        var courses = _db.Courses;
        var vm = new CourseListViewModel(courses.Include(c=>c.Teacher).Include(c=>c.Group));
        vm.GoBack.Subscribe(_ =>
        {
            Content = MainMenu;
        });
        Content = vm;
    }

    public void GoToExportView()
    {
        Content = new ExportViewModel();
    }

    public void GoToAddTeacherView()
    {
        var vm = new AddTeacherViewModel();
        vm.AddTeacher.Subscribe(teacher =>
        {
            if (teacher != null)
            {
                _db.Teachers.Add(teacher);
                _db.SaveChanges();
                Content = MainMenu;
            }
        });
        Content = vm;
    }

    public void GoToAddAbsenceView()
    {
        var vm = new AddAbsenceViewModel(_db);
        vm.AddAbsence.Subscribe(absence =>
        {
            if (absence != null)
            {
                _db.Absences.Add(absence);
                _db.SaveChanges();
                Content = MainMenu;
            }
        });
        Content = vm;
    }

    public void GoToAddMarkView()
    {
        var vm = new AddMarkViewModel(_db);
        vm.AddMark.Subscribe(mark =>
        {
            if (mark != null)
            {
                _db.Marks.Add(mark);
                _db.SaveChanges();
                Content = MainMenu;
            }
        });
        Content = vm;
    }
}
