using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using wt_lab4_mvc_pekarskaya.Models;

namespace wt_lab4_mvc_pekarskaya.Controllers
{
    public class StudentsController : Controller
    {
        private static List<Student> _students = new List<Student>
        {
            new Student { Id = 1, FullName = "Иванов Иван Иванович",       Group = "УИР-2", AverageGrade = 8.75, IsActive = false },
            new Student { Id = 2, FullName = "Остапчук Фиолента Андреевна", Group = "УИР-2", AverageGrade = 9.20, IsActive = true },
            new Student { Id = 3, FullName = "Лисейчиков Денис Олегович",   Group = "УИР-2", AverageGrade = 10.0, IsActive = true },
            new Student { Id = 4, FullName = "Винник Диана Денисовна",      Group = "УИР-3", AverageGrade = 9.50, IsActive = true },
            new Student { Id = 5, FullName = "Аляшевич Милана Витальевна",  Group = "УИР-3", AverageGrade = 8.90, IsActive = false }
        };

        // GET /Students
        public IActionResult Index()
        {
            return View(_students);
        }

        // GET /Students/Details/5
        public IActionResult Details(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) return View("NotFound");
            return View(student);
        }

        // ★ GET /Students/Create — ПОКАЗАТЬ ФОРМУ (1 уровень)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ★ POST /Students/Create — ОБРАБОТАТЬ ФОРМУ (2-3 уровень)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student); // вернуть форму с ошибками
            }

            student.Id = _students.Count == 0 ? 1 : _students.Max(s => s.Id) + 1;
            _students.Add(student);
            return RedirectToAction(nameof(Index));
        }
    }
}