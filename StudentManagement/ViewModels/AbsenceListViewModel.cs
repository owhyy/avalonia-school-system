using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class AbsenceListViewModel : ViewModelBase
{
    public AbsenceListViewModel(IEnumerable<Absence> absences)
    {
        Absences = new ObservableCollection<Absence>(absences);
        GoBack = ReactiveCommand.Create(() => { });
    }

    public ObservableCollection<Absence> Absences { get; }
    public ReactiveCommand<Unit, Unit> GoBack { get; }
}