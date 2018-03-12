using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateuszThomasZad5WebApi.Models
{
    public class ModelFactory
    {
        /// <summary>
        /// Tworzenie modelu studenta wykorzystywanego w programie na podstawie modelu studenta pobranego z bazy danych
        /// </summary>
        /// <param name="students"></param>
        /// <returns></returns>
        public StudentsModel Create(Students students)
        {
            return new StudentsModel()
            {
                id = students.ID,
                name = students.Name,
                surname = students.Surname,
                email = students.Email,
                phoneNumber = students.PhoneNumber,
                indexNumber = students.IndexNumber,
                universityID = students.UniversityID,
                tasks = students.Tasks.Select(t => Create(t))
            };
        }
        /// <summary>
        /// Tworzenie modelu zadania wykorzystywanego w programie na podstawie modelu zadania pobranego z bazy danych
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public TasksModel Create(Tasks tasks)
        {
            return new TasksModel()
            {
                id = tasks.ID,
                name = tasks.Name,
                deadline = tasks.Deadline,
                studentID = tasks.StudentID
            };
        }
        /// <summary>
        /// Tworzenie modelu uniwersytetu wykorzystywanego w programie na podstawie modelu uniwersytetu pobranego z bazy danych
        /// </summary>
        /// <param name="university"></param>
        /// <returns></returns>
        public UniversityModel Create(University university)
        {
            return new UniversityModel()
            {
                id = university.ID,
                name = university.Name,
                students = university.Students.Select(s => Create(s))
            };
        }
    }
}