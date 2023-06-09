using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Services;

public class Database : DbContext
{
    public Database()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "students.db");
    }

    private string DbPath { get; }

    public DbSet<Student> Students { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Mark> Marks { get; set; }
    public DbSet<Absence> Absences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}