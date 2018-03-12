using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateuszThomasZad5WebApi.Models
{
    public class StudentsModel
    {
        /// <summary>
        /// ID studenta. Klucz główny z bazy danych
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Imie
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Nazwisko
        /// </summary>
        public string surname { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Numer telefonu
        /// </summary>
        public string phoneNumber { get; set; }
        /// <summary>
        /// Numer indeksu
        /// </summary>
        public string indexNumber { get; set; }
        /// <summary>
        /// Numer uczelni
        /// </summary>
        public int universityID { get; set; }

        /// <summary>
        /// List zadań do wykonania
        /// </summary>
        public IEnumerable<TasksModel> tasks { get; set; }
    }
}