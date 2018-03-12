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
    [RoutePrefix("api/Universities")]
    public class UniversitiesController : ApiController
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
        public UniversitiesController()
        {
            _modelFactory = new Models.ModelFactory();
        }
        /// <summary>
        /// Funkcja zwracajaca wszystkie uczelnie z bazy danych.
        /// </summary>
        /// <returns></returns>
        // GET: api/Universities
        [HttpGet, Route("")]
        public IEnumerable<UniversityModel> GetUniversity()
        {
            return db.University.ToList().Select(u => _modelFactory.Create(u));
        }
        /// <summary>
        /// Funkcja zwracajaca uczelnie o podanym numerze ID
        /// GET: api/Universities/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:int}", Name = "GetUniversity")]
        [ResponseType(typeof(UniversityModel))]
        public IHttpActionResult GetUniversity(int id)
        {
            University university = db.University.Find(id);
            if (university == null)
            {
                return NotFound();
            }
            UniversityModel universityModel = _modelFactory.Create(university);
            return Ok(universityModel);
        }
        /// <summary>
        /// Funkcja modyfikująca dane o uczelni o podanym numerze ID.
        /// PUT: api/Universities/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="university"></param>
        /// <returns></returns>
        [HttpPut, Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUniversity(int id, [FromBody] University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            university.ID = id;
            db.Entry(university).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UniversityExists(id))
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
        /// Funkcja dodająca uczelnie do bazy danych.
        /// POST: api/Universities
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [ResponseType(typeof(UniversityModel))]
        public IHttpActionResult PostUniversity([FromBody] University university)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.University.Add(university);
            db.SaveChanges();
            UniversityModel universityModel = _modelFactory.Create(university);
            return CreatedAtRoute("GetUniversity", new { id = university.ID }, universityModel);
        }
        /// <summary>
        ///  Funkcja usuwajaca uczelnie o podanym numerze ID z bazy danych.
        ///  DELETE: api/Universities/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // 
        [HttpDelete, Route("{id:int}")]
        [ResponseType(typeof(UniversityModel))]
        public IHttpActionResult DeleteUniversity(int id)
        {
            University university = db.University.Find(id);
            if (university == null)
            {
                return NotFound();
            }

            db.University.Remove(university);
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
        /// Funkcja sprawdza czy istnieje uczelnia o podanym numerze ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool UniversityExists(int id)
        {
            return db.University.Count(e => e.ID == id) > 0;
        }
    }
}