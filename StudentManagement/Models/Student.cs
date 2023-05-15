using System;

namespace StudentManagement.Models;


public enum Gender {}
public enum Grade {}


public class Student
{
    public int studentId { get; set; }
    public string firstName { get; set; }
    public string lastName { get; set; }
    public DateTime birthDate { get; set; }
    public Gender gender { get; set; }
    public Grade grade { get; set; }
}