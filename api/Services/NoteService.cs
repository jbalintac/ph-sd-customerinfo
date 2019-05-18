using System;
using System.Collections.Generic;
using System.Linq;
using CustomerInfo.Data;
using CustomerInfo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerInfo.Services
{
    public class NoteService
    {
        private CustomerContext customerContext;

        public NoteService(CustomerContext customerContext)
        {
            this.customerContext = customerContext;
        }

        public List<Note> GetAll() 
        {
            return customerContext.Set<Note>().ToList();
        }

        public Note GetById(Guid id)
        {
            return customerContext.Set<Note>().SingleOrDefault(c => c.Id == id);
        }

        public Note Add(Note note)
        {
            // TODO: Validate FK
            var noteData = new Note 
            {
                Id = Guid.NewGuid(),
                CustomerId = note.CustomerId,
                Value = note.Value
            };

            customerContext.Add(noteData);
            customerContext.SaveChanges();

            return noteData;
        }

        public Note Update(Guid id, Note note)
        {
            var noteData = customerContext.Set<Note>().SingleOrDefault(c => c.Id == id);

            if(noteData != null) 
            {
                noteData.Value = note.Value;

                customerContext.Update(noteData);
                customerContext.SaveChanges();
            }

            return noteData;
        }

        public void Delete(Guid id)
        {
            var note = customerContext.Set<Note>().SingleOrDefault(c => c.Id == id);

            if(note != null) 
            {
                customerContext.Remove(note);
                customerContext.SaveChanges();
            }
        }
    }
}
