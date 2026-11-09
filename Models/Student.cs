using System;
using System.ComponentModel.DataAnnotations;

namespace wt_lab4_mvc_pekarskaya.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите ФИО")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Введите группу")]
        public string Group { get; set; } = string.Empty;

        [Range(0, 10, ErrorMessage = "Балл должен быть от 0 до 10")]
        public double AverageGrade { get; set; }

        public bool IsActive { get; set; } = true;
    }
}