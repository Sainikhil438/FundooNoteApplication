using BusinessLayer.Interface;
using CommonLayer.Models;
using RepoLayer.Entity;
using RepoLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBusiness : INoteBusiness
    {
        private readonly INoteRepo NoteRepo;
        public NoteBusiness(INoteRepo NoteRepo)
        {
            this.NoteRepo = NoteRepo;
        }

        public NoteEntity CreateNote(NoteModel noteModel, long userID)
        {
            try
            {
                return NoteRepo.CreateNote(noteModel, userID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string UpdateNoteById(long Notesid, string Takenote)
        {
            try
            {
                return NoteRepo.UpdateNoteById(Notesid, Takenote);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long DeleteNote(long Noteid)
        {
            try
            {
                return NoteRepo.DeleteNote(Noteid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NoteEntity> GetParticularUser(long UserId)
        {
            try
            {
                return NoteRepo.GetParticularUser(UserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string UpdateColour(long Noteid, string colour, long Userid)
        {
            try
            {
                return NoteRepo.UpdateColour(Noteid, colour, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ArchiveByNoteId(long Noteid, long Userid)
        {
            try
            {
                return NoteRepo.ArchiveByNoteId(Noteid, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool PinByNoteId(long Noteid, long Userid)
        {
            try
            {
                return NoteRepo.PinByNoteId(Noteid, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool TrashByNoteId(long Noteid, long Userid)
        {
            try
            {
                return NoteRepo.TrashByNoteId(Noteid, Userid);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}
