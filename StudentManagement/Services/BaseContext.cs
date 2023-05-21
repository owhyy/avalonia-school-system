using System;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace StudentManagement.Services;

public abstract class BaseContext : DbContext
{
    protected BaseContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "students.db");
    }

    private string DbPath { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite($"Data Source={DbPath}");
    }
}
