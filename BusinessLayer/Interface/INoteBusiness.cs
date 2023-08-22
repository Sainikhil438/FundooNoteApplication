using CommonLayer.Models;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBusiness
    {
        public NoteEntity CreateNote(NoteModel noteModel, long userID);
        public string UpdateNoteById(long Notesid, string Takenote);
        public long DeleteNote(long Noteid);
        public List<NoteEntity> GetParticularUser(long UserId);
        public string UpdateColour(long Noteid, string colour, long Userid);
        public bool ArchiveByNoteId(long Noteid, long Userid);
        public bool PinByNoteId(long Noteid, long Userid);
        public bool TrashByNoteId(long Noteid, long Userid);
        
    }
}
