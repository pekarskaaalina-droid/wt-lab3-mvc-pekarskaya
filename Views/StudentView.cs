using System;
using System.Collections.Generic;
using UniversityApp.Models;

namespace UniversityApp.Views
{
    /// <summary>
    /// View — отвечает ТОЛЬКО за вывод информации в консоль.
    /// </summary>
    public class StudentView
    {
        public void ShowStudents(List<Student> students)
        {
            Console.WriteLine();
            Console.WriteLine("=== Список студентов ===");

            if (students.Count == 0)
            {
                Console.WriteLine("  (список пуст)");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"  {s}");
            }
        }

        public void ShowStudent(Student student)
        {
            Console.WriteLine();
            Console.WriteLine("=== Информация о студенте ===");
            Console.WriteLine($"  Id:           {student.Id}");
            Console.WriteLine($"  ФИО:          {student.FullName}");
            Console.WriteLine($"  Группа:       {student.Group}");
            Console.WriteLine($"  Средний балл: {student.AverageGrade:F2}");
        }

        public void ShowMessage(string message)
        {
            Console.WriteLine();
            Console.WriteLine($">>> {message}");
        }

        /// <summary>
        /// Показать консольное меню.
        /// </summary>
        public void ShowMenu()
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("  1. Показать всех студентов");
            Console.WriteLine("  2. Найти студента по Id");
            Console.WriteLine("  3. Добавить студента");
            Console.WriteLine("  4. Удалить студента по Id");
            Console.WriteLine("  5. Отличники (средний балл >= 9)");
            Console.WriteLine("  0. Выход");
            Console.Write("Выберите пункт: ");
        }
    }
}