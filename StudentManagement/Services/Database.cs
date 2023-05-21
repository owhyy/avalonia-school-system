using System.Collections.ObjectModel;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class Database
// Simple wrapper class to avoid passing 3 arguments to MainWindowView
// and create contexts for each action
{
    public ObservableCollection<Student> getStudents()
    {
        using (var context = new StudentContext())
        {
            var students = context.Students;
            return new ObservableCollection<Student>(students);
        }
    }

    public void addStudent(Student student)
    {
        using var context = new StudentContext();
        context.Add(student);
        context.SaveChanges();
    }

    public ObservableCollection<User> getUsers()
    {
        using var context = new UserContext();
        return new ObservableCollection<User>(context.Users);
    }
}
