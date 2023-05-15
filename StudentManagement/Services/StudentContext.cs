using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class StudentContext: BaseContext
{
    public DbSet<Student> Students { get; set; }
}
