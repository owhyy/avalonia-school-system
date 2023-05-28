using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class MarkListViewModel : ViewModelBase
{
    public MarkListViewModel(IEnumerable<Mark> marks)
    {
        Marks = new ObservableCollection<Mark>(marks);
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<Mark> Marks { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}