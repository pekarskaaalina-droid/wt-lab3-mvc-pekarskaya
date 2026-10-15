using System;

namespace UniversityApp.Models
{
    /// <summary>
    /// Модель предметной области «Студент».
    /// Отвечает ТОЛЬКО за хранение данных.
    /// </summary>
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Group { get; set; } = string.Empty;
        public double AverageGrade { get; set; }

        public override string ToString()
        {
            return $"#{Id} {FullName} ({Group}) — балл {AverageGrade:F2}";
        }
    }
}