using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MateuszThomasZad5WebApi.Models
{
    public class TasksModel
    {
        /// <summary>
        /// Numer ID w bazie danych. Klucz główny.
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// Treść zadania do wykonania.
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// Termin wykonania zadania.
        /// </summary>
        public System.DateTime deadline { get; set; }
        /// <summary>
        /// Numer ID studenta, który ma wykonać dane zadanie.
        /// </summary>
        public int studentID { get; set; }
    }
}