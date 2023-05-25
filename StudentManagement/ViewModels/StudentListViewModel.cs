using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class StudentListViewModel : ViewModelBase
{
    public StudentListViewModel(IEnumerable<Student> students)
    {
        Students = new ObservableCollection<Student>(students);
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<Student> Students { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}
