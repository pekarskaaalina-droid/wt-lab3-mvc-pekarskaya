using System;
using System.Collections.Generic;
using System.Linq;
using UniversityApp.Models;
using UniversityApp.Views;

namespace UniversityApp.Controllers
{
    /// <summary>
    /// Controller — принимает команды пользователя,
    /// работает с Model и передаёт данные во View.
    /// </summary>
    public class StudentController
    {
        private readonly List<Student> _students;
        private readonly StudentView _view;

        public StudentController()
        {
            _students = new List<Student>
            {
                new Student { Id = 1, FullName = "Иванов Иван Иванович",       Group = "УИР-2", AverageGrade = 8.75 },
                new Student { Id = 2, FullName = "Остапчук Фиолента Андреевна", Group = "УИР-2", AverageGrade = 9.20 },
                new Student { Id = 3, FullName = "Лисейчиков Денис Олегович",   Group = "УИР-2", AverageGrade = 10.0 },
                new Student { Id = 4, FullName = "Винник Диана Денисовна",      Group = "УИР-2", AverageGrade = 9.50 },
                new Student { Id = 5, FullName = "Аляшевич Милана Витальевна",  Group = "УИР-2", AverageGrade = 8.90 }
            };

            _view = new StudentView();
        }

        public void Index()
        {
            _view.ShowStudents(_students);
        }

        public void Show(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                _view.ShowMessage($"Студент с Id={id} не найден.");
                return;
            }

            _view.ShowStudent(student);
        }

        public void Add(Student student)
        {
            _students.Add(student);
            _view.ShowMessage($"Студент «{student.FullName}» успешно добавлен.");
        }

        public void Delete(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                _view.ShowMessage($"Студент с Id={id} не найден — удаление невозможно.");
                return;
            }

            _students.Remove(student);
            _view.ShowMessage($"Студент «{student.FullName}» удалён.");
        }

        /// <summary>
        /// ДОПОЛНИТЕЛЬНАЯ ОПЕРАЦИЯ: показать отличников (балл >= 9.0).
        /// </summary>
        public void ShowExcellent()
        {
            var excellent = _students.Where(s => s.AverageGrade >= 9.0).ToList();

            _view.ShowMessage($"Отличники (балл >= 9): найдено {excellent.Count}");
            _view.ShowStudents(excellent);
        }

        public StudentView GetView()
        {
            return _view;
        }

        public int NextId()
        {
            return _students.Count == 0 ? 1 : _students.Max(s => s.Id) + 1;
        }
    }
}