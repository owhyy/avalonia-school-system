using System.Reactive;
using ReactiveUI;

namespace StudentManagement.ViewModels;

// TODO: finish implementing
public class CustomFunctionsViewModel : ViewModelBase
{
    public ReactiveCommand<Unit, Unit> CreateTableWithStudentsThatStudyTwoOrMoreSubjects;
    public ReactiveCommand<Unit, Unit> DeleteStudentsWithAverageGradeLessThan7;
    public ReactiveCommand<Unit, Unit> DeleteSubject;
    public ReactiveCommand<Unit, Unit> ShowMostStudiedSubject;
    public ReactiveCommand<Unit, Unit> ShowTotalAbsences;
}