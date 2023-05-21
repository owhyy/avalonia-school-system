using System;
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

        var vm = new LoginViewModel(_db.getUsers());
        vm.Login.Subscribe(validCredentials =>
        {
            if (validCredentials)
            {
                Content = MainMenu = new MenuViewModel();
            }
        });
        Content = vm;
    }

    public StudentListViewModel StudentList { get; }
    public MenuViewModel MainMenu { get; set; }
    public CourseListViewModel CourseList { get; }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void GoToAddStudentView()
    {
        var vm = new AddStudentViewModel();
        vm.AddStudent.Subscribe(student =>
        {
            if (student != null)
            {
                _db.addStudent(student);
                Content = MainMenu;
            }
        });
        Content = vm;
    }

    public void GoToStudentListView()
    {
        Content = StudentList;
    }

    public void GoToSettingsView()
    {
        Content = new SettingsViewModel();
    }

    public void GoToAddCourseView()
    {
        Content = new AddCourseViewModel();
    }

    public void GoToCourseListView()
    {
        Content = new CourseListViewModel();
    }

    public void GoToExportView()
    {
        Content = new ExportViewModel();
    }
}
