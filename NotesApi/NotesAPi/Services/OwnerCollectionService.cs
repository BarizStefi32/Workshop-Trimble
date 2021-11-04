using MongoDB.Driver;
using NotesAPi.Models;
using NotesAPi.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Services
{
    public class OwnerCollectionService : IOwnerCollectionService
    {

        private readonly IMongoCollection<Owner> _owners;

        public OwnerCollectionService(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _owners = database.GetCollection<Owner>(settings.OwnerCollectionName);
        }


        public async Task<bool> Create(Owner owner)
        {
            await _owners.InsertOneAsync(owner);
            return true;
        }


        public async Task<bool> Delete(Guid id)
        {
            var result = await _owners.DeleteOneAsync(owner => owner.Id == id);
            if (!result.IsAcknowledged && result.DeletedCount == 0)
            {
                return false;
            }
            return true;
        }


        public async Task<List<Owner>> GetAll()
        {
            try
            {
                var result = await _owners.FindAsync(owner => true);
                return result.ToList();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
            
        }



        public async Task<Owner> Get(Guid id)
        {
            return (await _owners.FindAsync(owner => owner.Id == id)).FirstOrDefault();
        }
       

        public async Task<bool> Update(Guid id, Owner owner)
        {
            owner.Id = id;
            var result = await _owners.ReplaceOneAsync(owner => owner.Id == id, owner);
            if (!result.IsAcknowledged && result.ModifiedCount == 0)
            {
                await _owners.InsertOneAsync(owner);
                return false;
            }

            return true;
        }

        public async Task<List<Notes>> GetNotesByOwnerId(Guid ownerId)
        {
            return null;

        }


    }
}
