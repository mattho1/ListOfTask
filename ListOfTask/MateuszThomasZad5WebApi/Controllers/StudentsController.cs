using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MateuszThomasZad5WebApi.Models;

namespace MateuszThomasZad5WebApi.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentsController : ApiController
    {
        /// <summary>
        /// Połączenie z bazą danych. Kontekst z bazy danych.
        /// </summary>
        private MateuszThomasZad5WebApiEntities db = new MateuszThomasZad5WebApiEntities();
        /// <summary>
        /// Obiekt tworzący inne modele. Posiaga trzy metody tworzące odpowiedni zadania, studentów i uczelnie.
        /// Tworzy obiekty na podstawie ich odpowiedników z bazy danych.
        /// </summary>
        ModelFactory _modelFactory;
        public StudentsController()
        {
            _modelFactory = new Models.ModelFactory();
        }
        /// <summary>
        ///Funkcja zwracajaca wszystkich studentów.
        /// GET: api/Students
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IEnumerable<StudentsModel> GetStudents()
        {

            return db.Students.ToList().Select(s => _modelFactory.Create(s));
        }
        /// <summary>
        /// Funkcja zwracajaca studenta o podanym numrze ID
        /// GET: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // 
        [HttpGet, Route("{id:int}", Name = "GetStudent")]
        [ResponseType(typeof(List<StudentsModel>))]
        public IHttpActionResult GetStudents(int id)
        {
            Students student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            StudentsModel studentModel = _modelFactory.Create(student);
            return Ok(studentModel);
        }
        /// <summary>
        /// Funkcja modyfikująca dane o studencie.
        /// PUT: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut, Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudents(int id, [FromBody] Students student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            student.ID = id;
            db.Entry(student).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
        /// <summary>
        /// Funkcja dodająca studenta.
        /// POST: api/Students
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [ResponseType(typeof(StudentsModel))]
        public IHttpActionResult PostStudents([FromBody] Students student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Students.Add(student);
            db.SaveChanges();
            StudentsModel studentModel = _modelFactory.Create(student);
            return CreatedAtRoute("GetStudent", new { id = student.ID }, studentModel);
        }
        /// <summary>
        /// Funkcja usuwajaca studenta.
        /// DELETE: api/Students/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteStudents(int id)
        {
            Students student = db.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.NoContent);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Funkcja sprawdza czy istnieje student o podanym numerze ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool StudentsExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}