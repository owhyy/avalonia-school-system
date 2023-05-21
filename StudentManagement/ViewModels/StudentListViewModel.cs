using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.ViewModels;

public class StudentListViewModel : ViewModelBase
{
    public StudentListViewModel(ObservableCollection<Student> students)
    {
        Students = students;
    }

    public ObservableCollection<Student> Students { get; }
}
