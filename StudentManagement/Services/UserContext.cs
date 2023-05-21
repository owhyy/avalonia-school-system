using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class UserContext : BaseContext
{
    public DbSet<User> Users { get; set; }
}
