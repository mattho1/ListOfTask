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
    [RoutePrefix("api/Tasks")]
    public class TasksController : ApiController
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
        public TasksController()
        {
            _modelFactory = new Models.ModelFactory();
        }
        /// <summary>
        /// Funkcja zwracajaca wszystkie zadania.
        /// GET: api/Tasks
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public IEnumerable<TasksModel> GetTasks()
        {
            return db.Tasks.ToList().Select(t => _modelFactory.Create(t));
        }
        /// <summary>
        /// Funkcja zwracajaca zadanie o podanym numrze ID
        /// GET: api/Tasks/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id:int}", Name = "GetTask")]
        [ResponseType(typeof(TasksModel))]
        public IHttpActionResult GetTasks(int id)
        {
            Tasks task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            TasksModel taskModel = _modelFactory.Create(task);
            return Ok(taskModel);
        }
        /// <summary>
        /// Funkcja modyfikująca dane o zadaniu o podanym numerze ID.
        /// PUT: api/Tasks/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tasks"></param>
        /// <returns></returns>
        [HttpPut, Route("{id:int}")]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTasks(int id, [FromBody] Tasks tasks)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tasks.ID = id;

            db.Entry(tasks).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
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
        /// Funkcja dodająca zadanie.
        /// POST: api/Tasks
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        [ResponseType(typeof(TasksModel))]
        public IHttpActionResult PostTasks([FromBody] Tasks task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Tasks.Add(task);
            db.SaveChanges();
            TasksModel taskModel = _modelFactory.Create(task);
            return CreatedAtRoute("GetTask", new { id = task.ID }, taskModel);
        }
        /// <summary>
        ///  Funkcja usuwajaca zadanie o podanym numerze ID.
        ///  DELETE: api/Tasks/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id:int}")]
        public IHttpActionResult DeleteTasks(int id)
        {
            Tasks task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }
            db.Tasks.Remove(task);
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
        /// Funkcja sprawdza czy istnieje zadanie o podanym numerze ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        private bool TasksExists(int id)
        {
            return db.Tasks.Count(e => e.ID == id) > 0;
        }
    }
}