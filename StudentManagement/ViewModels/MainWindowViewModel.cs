using System; using ReactiveUI;

namespace StudentManagement.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    ViewModelBase _content;

    public MainWindowViewModel()
    {
        var vm = new LoginViewModel();
        vm.Login.Subscribe(validCredentials =>
        {
            if (validCredentials)
                Content = new MenuViewModel();
        });
        Content = vm;
    }

    public ViewModelBase Content
    {
        get => _content;
        private set => this.RaiseAndSetIfChanged(ref _content, value);
    }

    public void GoToAddStudentView()
    {
        Content = new AddStudentViewModel();
    }
    
    public void GoToStudentListView()
    {
        Content = new StudentListViewModel();
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