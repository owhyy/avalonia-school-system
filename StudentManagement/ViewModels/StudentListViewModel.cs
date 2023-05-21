using System.Collections.ObjectModel;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class StudentListViewModel : ViewModelBase
{
    public StudentListViewModel(ObservableCollection<Student> students)
    {
        Students = students;
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<Student> Students { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}
