using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using NotesAPi.Models;
using NotesAPi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Services
{
    public class NoteCollectionService : INoteCollectionService
    {

        private readonly IMongoCollection<Notes> _notes;

        public NoteCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _notes = database.GetCollection<Notes>(settings.NoteCollectionName);
        }

        public async Task<List<Notes>> GetAll()
        {
            var result = await _notes.FindAsync(note => true);
            return result.ToList();
        }


        public async Task<bool> Create(Notes note)
        {
            await _notes.InsertOneAsync(note);
            return true;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = await _notes.DeleteOneAsync(note => note.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<Notes> Get(Guid id)
        {
            return (await _notes.FindAsync(note => note.Id == id)).FirstOrDefault();
        }

        public async Task<bool> Update(Guid id, Notes note)
        {
            note.Id = id;
            var result = await _notes.ReplaceOneAsync(note => note.Id == id, note);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _notes.InsertOneAsync(note);
                return false;
            }

            return true;
        }

        public async Task<List<Notes>> GetNotesByOwnerId(Guid ownerId)
        {
            return (await _notes.FindAsync(note => note.OwnerId == ownerId)).ToList();
        }





        //private List<Notes> _notes = new List<Notes> { new Notes { Id = new Guid("00000000-0000-0000-0000-000000000001"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "First Note", Description = "First Note Description" },
        //new Notes { Id = new Guid("00000000-0000-0000-0000-000000000002"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Second Note", Description = "Second Note Description" },
        //new Notes { Id = new Guid("00000000-0000-0000-0000-000000000003"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Third Note", Description = "Third Note Description" },
        //new Notes { Id = new Guid("00000000-0000-0000-0000-000000000004"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fourth Note", Description = "Fourth Note Description" },
        //new Notes { Id = new Guid("00000000-0000-0000-0000-000000000005"), CategoryId = "1", OwnerId = new Guid("00000000-0000-0000-0000-000000000001"), Title = "Fifth Note", Description = "Fifth Note Description" }
        //};

        //public NoteCollectionService() { }

        //public bool Create(Notes model)
        //{
        //    _notes.Add(model);
        //    bool isAdded = _notes.Contains(model);
        //    return isAdded;
        //}

        //public bool Delete(Guid id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Notes Get(Guid id)
        //{
        //    return  _notes.FirstOrDefault(note => note.Id == id);

        //}

        //public List<Notes> GetAll()
        //{
        //    return _notes;
        //}

        //public List<Note> GetNotesByOwnerId(Guid ownerId)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(Guid id, Notes model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
