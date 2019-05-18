using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInfo.Services;
using CustomerInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;

namespace CustomerInfo.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private CustomerService customerService;
        private NoteService noteService;

        public NotesController(NoteService noteService, CustomerService customerService)
        {
            this.noteService = noteService;
            this.customerService = customerService;
        }

        // GET api/notes
        [HttpGet]
        public ActionResult<IEnumerable<Note>> Get()
        {
            return noteService.GetAll();
        }

        // GET api/notes/5
        [HttpGet("{id}")]
        public ActionResult<Note> GetById(Guid id)
        {
            var note = noteService.GetById(id);

            if(note == null) return NotFound();
            return note;
        }

        //POST api/notes
        [HttpPost]
        public ActionResult<Note> Post([FromBody] Note value)
        {
            if(customerService.GetById(value.CustomerId) == null)
            {
                ModelState.AddModelError("CustomerId", "Customer Id doesn't exist.");
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);;
            }

            return noteService.Add(value);
        }

        // PUT api/notes/5
        [HttpPut("{id}")]
        public ActionResult<Note> Put(Guid id, [FromBody] Note value)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);;
            }

            return noteService.Update(id, value);
        }

        //DELETE api/notes/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            noteService.Delete(id);
        }
    }
}
