using System;
using UniversityApp.Controllers;
using UniversityApp.Models;

namespace UniversityApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var controller = new StudentController();
            var view = controller.GetView();

            bool running = true;

            while (running)
            {
                view.ShowMenu();
                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "1":
                        controller.Index();
                        break;

                    case "2":
                        Console.Write("Введите Id: ");
                        if (int.TryParse(Console.ReadLine(), out int id))
                            controller.Show(id);
                        else
                            view.ShowMessage("Некорректный Id!");
                        break;

                    case "3":
                        Console.Write("ФИО: ");
                        string name = Console.ReadLine() ?? "";
                        Console.Write("Группа: ");
                        string group = Console.ReadLine() ?? "";
                        Console.Write("Средний балл: ");
                        if (double.TryParse(Console.ReadLine(), out double grade))
                        {
                            controller.Add(new Student
                            {
                                Id = controller.NextId(),
                                FullName = name,
                                Group = group,
                                AverageGrade = grade
                            });
                        }
                        else
                            view.ShowMessage("Некорректный балл!");
                        break;

                    case "4":
                        Console.Write("Введите Id для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int delId))
                            controller.Delete(delId);
                        else
                            view.ShowMessage("Некорректный Id!");
                        break;

                    case "5":
                        controller.ShowExcellent();
                        break;

                    case "0":
                        running = false;
                        view.ShowMessage("Выход из программы. До свидания!");
                        break;

                    default:
                        view.ShowMessage("Неизвестная команда. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}