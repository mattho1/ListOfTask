using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateuszThomasZad5WebApi.Models
{
    public class UniversityModel
    {
        /// <summary>
        /// Numer ID uczelni w bazie danych. Klucz główny w bazie danych.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Nazwa uczelni.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Lista studentów należących do uczelni.
        /// </summary>
        public IEnumerable<StudentsModel> students { get; set; }
    }
}