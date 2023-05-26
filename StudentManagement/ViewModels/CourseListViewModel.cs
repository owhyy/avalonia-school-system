using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class CourseListViewModel : ViewModelBase
{
    public CourseListViewModel(IEnumerable<Course> courses)
    {
        Courses = new ObservableCollection<Course>(courses);
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<Course> Courses { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}
