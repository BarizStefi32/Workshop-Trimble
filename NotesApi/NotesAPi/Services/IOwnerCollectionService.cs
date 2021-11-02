using NotesAPi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAPi.Services
{
    public interface IOwnerCollectionService : ICollectionService<Owner>
    {
        Task<List<Notes>> GetNotesByOwnerId(Guid ownerId);
    }


}
