using CommonLayer.Models;
using RepoLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepoLayer.Interface
{
    public interface INoteRepo
    {
        public NoteEntity CreateNote(NoteModel noteModel, long userID);
        public string UpdateNoteById(long Notesid, string Takenote);
        public long DeleteNote(long Noteid);
        public List<NoteEntity> GetParticularUser(long UserId);
    }
}
